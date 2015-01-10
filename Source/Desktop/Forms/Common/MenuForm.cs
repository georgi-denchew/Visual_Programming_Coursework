using Desktop.Forms.Identity;
using Desktop.Forms.Transport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms.Common
{
    public partial class MenuForm : BaseForm
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var form in this.MdiChildren)
            {
                if (form is LoginForm)
                {
                    form.Focus();
                    return;
                }
            }

            LoginForm loginForm = new LoginForm();
            loginForm.MdiParent = this;

            loginForm.Show();
        }
        private void ToolStripMenuItemAbout_Click(object sender, System.EventArgs e)
        {
            foreach (var form in this.MdiChildren)
            {
                if (form is About)
                {
                    form.Focus();
                    return;
                }
            }

            About about = new About();
            about.MdiParent = this;
            about.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfo.UserId = -1;

            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }

            this.LogoutToolStripMenuItem.Visible = false;
            this.TransportsToolStripMenuItem.Visible = false;
            this.ReportsToolStripMenuItem.Visible = false;
            this.LogInToolStripMenuItem.Visible = true;
        }

        private void transportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var form in this.MdiChildren)
            {
                if (form is AllTransports)
                {
                    form.Focus();
                    return;
                }
            }

            AllTransports allTransports = new AllTransports();
            allTransports.MdiParent = this;
            allTransports.Show();
        }

        internal void RefreshOrders()
        {
            foreach (var childForm in this.MdiChildren)
            {
                if (childForm is Order.MyOrders2)
                {
                    (childForm as Order.MyOrders2).RefreshOrdersDataGrid();
                }
            }
        }

        internal void OpenAddEditOrder()
        {
            foreach (var childForm in this.MdiChildren)
            {
                if (childForm is Order.AddEditOrder)
                {
                    (childForm as Order.AddEditOrder).Focus();
                    return;
                }
            }

            Order.AddEditOrder addEditOrder = new Order.AddEditOrder();
            addEditOrder.MdiParent = this;
            addEditOrder.Show();
        }

        internal void OpenAddEditOrder(OrdersSystem.Data.Order order)
        {
            foreach (var childForm in this.MdiChildren)
            {
                if (childForm is Order.AddEditOrder)
                {
                    (childForm as Order.AddEditOrder).Close();
                }
            }

            Order.AddEditOrder addEditOrder = new Order.AddEditOrder(order);
            addEditOrder.MdiParent = this;
            addEditOrder.Show();
        }

        internal void OpenOrdersSearch()
        {
            Search.SearchMyOrders searchMyOrders = new Search.SearchMyOrders();
            searchMyOrders.ShowDialog();
        }

        internal void OpenBooksSearch()
        {
            Search.SearchMyBooks searchMyBooks = new Search.SearchMyBooks();
            searchMyBooks.ShowDialog();
        }

        internal void SearchOrders(string deliveryAddress, string country, DateTime modificationDate, string beforeAfter)
        {
            foreach (var childForm in this.MdiChildren)
            {
                if (childForm is Order.MyOrders2)
                {
                    (childForm as Order.MyOrders2).SearchOrders(deliveryAddress, country, modificationDate, beforeAfter);
                    childForm.Focus();
                }
            }
        }

        internal void SearchBooks(string title, string isbn, DateTime modificationDate, string beforeAfter)
        {
            foreach (var childForm in this.MdiChildren)
            {
                if (childForm is Order.MyOrders2)
                {
                    (childForm as Order.MyOrders2).SearchBooks(title, isbn, modificationDate, beforeAfter);
                    childForm.Focus();
                }
            }
        }

        private void myTransportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.MyTransportsReport myTransportsReport = new Reports.MyTransportsReport();
            myTransportsReport.Show();
        }

        private void myOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void myBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}