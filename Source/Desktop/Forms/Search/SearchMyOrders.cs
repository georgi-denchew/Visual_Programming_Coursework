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
    public partial class SearchMyOrders : BaseForm
    {
        public SearchMyOrders()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string deliveryAddress = this.textBoxDeliveryAddress.Text;
            string country = this.textBoxCountry.Text;
            DateTime modificationDate = this.dateTimePickerModificationDate.Value.Date;
            string beforeAfter = this.comboBoxBeforeAfter.SelectedItem.ToString();

            foreach (var form in Application.OpenForms)
            {
                if (form is Order.MyOrders2)
                {
                    (form as Order.MyOrders2).SearchOrders(deliveryAddress, country, modificationDate, beforeAfter);
                }
            }

            this.Close();
        }
    }
}
