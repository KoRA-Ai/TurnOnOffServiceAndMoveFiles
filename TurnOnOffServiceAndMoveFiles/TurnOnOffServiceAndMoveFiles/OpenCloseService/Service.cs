using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace OpenCloseService
{
    internal class Service
    {
        public string ServiceName { get; set; }
        public ServiceControllerStatus Status { get; set; }

        //public string Status1
        //{
        //    get
        //    {
        //    }

        //    set
        //    {
        //    }
        //}

        //public Service(string serviceName, ServiceControllerStatus status)
        //{
        //    this.ServiceName = serviceName;
        //    this.Status = status;
        //}
    }
}