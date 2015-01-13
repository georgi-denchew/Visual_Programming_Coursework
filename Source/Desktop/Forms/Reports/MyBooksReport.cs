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
    public partial class MyBooksReport : BaseForm
    {
        public MyBooksReport()
        {
            InitializeComponent();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = base.Data.Books
                .Where(x => x.UserId == UserInfo.UserId)
                .ToList();
            this.CrystalReportBooks1.SetDataSource(bindingSource);
            this.crystalReportViewer1.ReportSource = this.CrystalReportBooks1;
            this.crystalReportViewer1.RefreshReport();
        }
    }
}
