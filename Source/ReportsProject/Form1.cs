using Desktop.Forms.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = base.Data.Transports.ToList();
            this.CrystalReport11.SetDataSource(bindingSource);
            this.crystalReportViewer1.ReportSource = this.CrystalReport11;
            this.crystalReportViewer1.RefreshReport();
        }
    }
}
