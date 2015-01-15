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

namespace Desktop.Forms.Search
{
    public partial class SearchMyBooks : BaseForm
    {
        public SearchMyBooks()
        {
            InitializeComponent();

            this.comboBoxBeforeAfter.SelectedIndex = 0;
        }

        private void dateTimePickerModificationDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string title = this.textBoxTitle.Text;
            string isbn = this.textBoxISBN.Text;
            DateTime modificationDate = this.dateTimePickerModificationDate.Value.Date;
            string beforeAfter = this.comboBoxBeforeAfter.SelectedItem.ToString();

            //(this.MdiParent as MenuForm).SearchBooks(title, isbn, modificationDate, beforeAfter);

            this.Close();

            foreach (var childForm in Application.OpenForms)
            {
                if (childForm is Order.MyOrders2)
                {
                    (childForm as Order.MyOrders2).SearchBooks(title, isbn, modificationDate, beforeAfter);
                    (childForm as Order.MyOrders2).Focus();
                    return;
                }
            }
        }
    }
}
