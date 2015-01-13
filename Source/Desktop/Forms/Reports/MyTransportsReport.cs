using Desktop.Forms.Common;
using Desktop.Forms.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms.Reports
{
    public partial class MyTransportsReport : BaseForm
    {
        public MyTransportsReport()
        {
            InitializeComponent();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = base.Data.Transports
                .Where(x => x.Orders.Any(y => y.UserId == UserInfo.UserId))
                .ToList();
            this.CrystalReport11.SetDataSource(bindingSource);
            this.crystalReportViewer1.ReportSource = this.CrystalReport11;
            this.crystalReportViewer1.RefreshReport();


        }
    }
}
