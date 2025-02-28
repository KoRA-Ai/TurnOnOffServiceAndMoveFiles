using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TurnOnOffService
{
    public partial class FormService : Form
    {
        private BindingSource bindingSource;
        private ServiceManager serviceManager;
        private List<Service> services;
        private Timer timer = new Timer();

        public FormService()

        {
            InitializeComponent();
            this.KeyPreview = true;

            bindingSource = new BindingSource();
            serviceManager = new ServiceManager();

            DataGridViewButtonColumn colOpenBtn = new DataGridViewButtonColumn();
            colOpenBtn.HeaderText = "";
            colOpenBtn.Name = "colBtnOpen";
            colOpenBtn.Text = "開啟服務";
            colOpenBtn.Width = 100;
            colOpenBtn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(2, colOpenBtn);
            DataGridViewButtonColumn colCloseBtn = new DataGridViewButtonColumn();
            colCloseBtn.HeaderText = "";
            colCloseBtn.Name = "colBtnClose";
            colCloseBtn.Text = "關閉服務";
            colCloseBtn.Width = 100;
            colCloseBtn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(3, colCloseBtn);

            timer.Interval = 5000; //5s
            timer.Tick += Timer_Tick;

            btnSearch.Click += (s, e) => BtnSearch_Click();
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            this.FormClosed += (s, e) => { timer.Stop(); };
            this.KeyDown += Form_KeyDown;
        }

        private void OpenClose(bool isToOpen, string serviceName)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (isToOpen)
            {
                serviceManager.TurnOnService(serviceName);
            }
            else
            {
                serviceManager.TurnOffService(serviceName);
            }
            RefreshServiceState();

            Cursor.Current = Cursors.Arrow;
        }

        private void BtnSearch_Click()
        {
            if (timer.Enabled) timer.Stop();

            services = serviceManager.SearchServices(tbServiceName.Text);

            bindingSource.DataSource = services;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.AutoResizeColumn(2);

            timer.Start();
        }

        private void RefreshServiceState()
        {
            services = serviceManager.UpdateServices(services);

            bindingSource.DataSource = services;
            dataGridView1.Refresh();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string serviceName = dataGridView1.Rows[e.RowIndex].Cells["ServiceName"].Value.ToString();
            if (e.ColumnIndex == dataGridView1.Columns["colBtnOpen"].Index)
            {
                OpenClose(true, serviceName);
            }
            if (e.ColumnIndex == dataGridView1.Columns["colBtnClose"].Index)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                OpenClose(false, serviceName);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (services.Count() > 0)
            {
                RefreshServiceState();
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSearch_Click();
            }
        }
    }
}