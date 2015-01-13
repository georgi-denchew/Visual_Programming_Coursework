using Desktop.Forms.Common;
using Desktop.Forms.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms.Reports
{
    public partial class MyOrdersReport : BaseForm
    {
        public MyOrdersReport()
        {
            InitializeComponent();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = base.Data.Orders
                .Where(x => x.UserId == UserInfo.UserId)
                .ToList();
            this.CrystalReportOrders1.SetDataSource(bindingSource);
            this.crystalReportViewer1.ReportSource = this.CrystalReportOrders1;
            this.crystalReportViewer1.RefreshReport();
        }
    }
}
