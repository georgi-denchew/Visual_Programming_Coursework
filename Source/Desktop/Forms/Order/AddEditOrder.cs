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

namespace Desktop.Forms.Order
{
    public partial class AddEditOrder : BaseForm
    {
        private bool toEdit;

        public OrdersSystem.Data.Order Order { get; set; }


        public AddEditOrder(OrdersSystem.Data.Order order)
            : this()
        {
            this.toEdit = true;

            this.Order = order;

            this.textBoxCountry.Text = order.Country;
            this.textBoxDeliveryAddress.Text = order.DeliveryAddress;
        }

        public AddEditOrder()
        {
            InitializeComponent();
            this.DeliveryAddressErrorProvider = new ErrorProvider();
            this.CountryErrorProvider = new ErrorProvider();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DeliveryAddressErrorProvider.Clear();
            this.CountryErrorProvider.Clear();

            bool isValidDeliveryAddress = base.ValidateRequiredInputField(DeliveryAddressErrorProvider, BaseForm.RequiredFieldMessage, this.textBoxDeliveryAddress);
            bool isValidCountry = base.ValidateRequiredInputField(CountryErrorProvider, BaseForm.RequiredFieldMessage, this.textBoxCountry);
            bool hasErrors = !(isValidDeliveryAddress && isValidCountry);

            if (hasErrors)
            {
                return;
            }

            if (toEdit)
            {
                var orderToUpdate = base.Data.Orders.FirstOrDefault(x => x.OrderId == this.Order.OrderId);

                orderToUpdate.Country = this.textBoxCountry.Text;
                orderToUpdate.DeliveryAddress = this.textBoxDeliveryAddress.Text;
                base.Data.SaveChanges();
                var orders = base.Data.Orders.ToList();
                MessageBox.Show("Order Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Data.insertOrder(this.textBoxDeliveryAddress.Text, this.textBoxCountry.Text, UserInfo.UserId, UserInfo.CurrentTransportId);
                MessageBox.Show("Order Inserted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            if (this.MdiParent is MenuForm)
            {
                (this.MdiParent as MenuForm).RefreshOrders();
            }

            this.Close();
        }

        public ErrorProvider DeliveryAddressErrorProvider { get; set; }

        public ErrorProvider CountryErrorProvider { get; set; }
    }
}
