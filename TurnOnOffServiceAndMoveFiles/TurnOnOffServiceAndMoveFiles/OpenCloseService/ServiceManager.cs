using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Windows.Forms;

namespace OpenCloseService
{
    internal class ServiceManager
    {
        public ServiceManager()
        {
        }

        public List<Service> SearchServices(string filter)
        {
            return ServiceController.GetServices()
                                      .Where(sn => sn.ServiceName.ToUpper().Contains(filter.ToUpper()))
                                      .Select(s => new Service
                                      {
                                          ServiceName = s.ServiceName,
                                          Status = s.Status
                                      }).OrderBy(sn => sn.ServiceName).ToList();
        }

        public List<Service> UpdateServices(List<Service> services)
        {
            return ServiceController.GetServices()
                                      .Where(sn => services.Any(s => s.ServiceName == sn.ServiceName))
                                      .Select(s => new Service
                                      {
                                          ServiceName = s.ServiceName,
                                          Status = s.Status
                                      }).OrderBy(sn => sn.ServiceName).ToList();
        }

        public void TurnOnService(string serviceName)
        {
            try
            {
                foreach (var service in ServiceController.GetServices().Where(s => s.ServiceName == serviceName).ToList())
                {
                    if (service.Status == ServiceControllerStatus.Stopped)
                    {
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(serviceName + " 開啟失敗: " + ex.ToString());
            }
        }

        public void TurnOffService(string serviceName)
        {
            try
            {
                foreach (var service in ServiceController.GetServices().Where(s => s.ServiceName == serviceName).ToList())
                {
                    if (service.Status == ServiceControllerStatus.Running)
                    {
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(serviceName + " 開啟失敗: " + ex.ToString());
            }
        }
    }
}