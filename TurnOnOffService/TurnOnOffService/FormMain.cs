using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurnOnOffService.ChangeFiles;

namespace TurnOnOffService
{
    public partial class FormMain : Form
    {
        private FormService formService;
        private FormChangeFile formChangeFile;

        public FormMain()
        {
            InitializeComponent();
            formService = new FormService() { TopLevel = false, Dock = DockStyle.Fill, FormBorderStyle = FormBorderStyle.None };
            tabService.Controls.Add(formService);
            formService.Show();

            formChangeFile = new FormChangeFile() { TopLevel = false, Dock = DockStyle.Fill, FormBorderStyle = FormBorderStyle.None };
            tabChangeFile.Controls.Add(formChangeFile);
            formChangeFile.Show();
            this.FormClosed += (s, e) => { formService.Close(); formChangeFile.Close(); };
        }
    }
}