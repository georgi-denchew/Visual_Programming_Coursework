using Desktop.Forms.Common;
using Desktop.Forms.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms.Order
{
    public partial class MyOrders2 : BaseForm
    {
        private OrdersSystem.Data.Order order;
        private OrdersSystem.Data.Order currentOrder;
        private OrdersSystem.Data.Book book;

        public BindingList<OrdersSystem.Data.Book> Books { get; set; }

        public int CurrentOrderId { get; set; }

        public ErrorProvider titleErrorProvider { get; set; }
        public ErrorProvider isbnErrorProvider { get; set; }
        public ErrorProvider orderedCountErrorProvider { get; set; }

        public MyOrders2()
        {
            InitializeComponent();

            this.titleErrorProvider = new ErrorProvider();
            this.isbnErrorProvider = new ErrorProvider();
            this.orderedCountErrorProvider = new ErrorProvider();


            RefreshOrdersDataGrid();

            this.booksDataGridView.AutoGenerateColumns = true;

            this.Books = new BindingList<OrdersSystem.Data.Book>();

            if (Orders.Count() > 0)
            {
                this.currentOrder = Orders.First();
                this.CurrentOrderId = currentOrder.OrderId;
                this.Books = new BindingList<OrdersSystem.Data.Book>(currentOrder.Books.ToList());

                this.booksBindingSource.DataSource = Books;
                this.bindingNavigatorBooks.BindingSource = this.booksBindingSource;
                this.booksDataGridView.DataSource = this.booksBindingSource;
            }

            Shown += new EventHandler(MyOrders2_Shown);
        }

        public void MyOrders2_Shown(object sender, EventArgs args)
        {
            this.booksDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.booksDataGridView.MultiSelect = false;

            this.booksDataGridView.Columns[0].ReadOnly = true;
            this.booksDataGridView.Columns[4].ReadOnly = true;
            this.booksDataGridView.Columns[5].ReadOnly = true;
            this.booksDataGridView.Columns[6].ReadOnly = true;
            this.booksDataGridView.Columns[7].Visible = false;
        }

        public void RefreshOrdersDataGrid()
        {
            base.Data = new OrdersSystem.Data.OrdersEntities();
            this.Orders = new BindingList<OrdersSystem.Data.Order>
                                            (base.Data.Orders.Where(x =>
                                                x.TransportId == UserInfo.CurrentTransportId &&
                                                x.UserId == UserInfo.UserId)
                                                    .ToList());

            if (this.Orders.Count > 0)
            {
                this.order = this.Orders.First();
            }
            this.orderBindingSource.DataSource = this.Orders;
            this.orderDataGridView.DataSource = this.orderBindingSource;
            this.orderDataGridView.Refresh();
        }

        private void OrderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CurrentOrderId = Convert.ToInt32(this.orderDataGridView.SelectedRows[0].Cells[0].Value);

            if (this.CurrentOrderId < 1)
            {
                return;
            }

            this.order = base.Data.Orders.FirstOrDefault(x => x.OrderId == this.CurrentOrderId);
            this.Books = new BindingList<OrdersSystem.Data.Book>(order.Books.ToList());

            if (this.Books.Count > 0)
            {
                refreshBookFields(this.Books.First().BookId);
            }

            RefreshBooksDataGrid(this.CurrentOrderId);
        }

        public BindingList<OrdersSystem.Data.Order> Orders { get; set; }

        private void toolStripMenuItemAddNew_Click(object sender, EventArgs e)
        {
            (this.MdiParent as MenuForm).OpenAddEditOrder();
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (this.orderDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order first!", "No order selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var orderId = Convert.ToInt32(this.orderDataGridView.SelectedRows[0].Cells[0].Value);
            var order = this.Orders.FirstOrDefault(x => x.OrderId == orderId);

            if (order != null)
            {
                (this.MdiParent as MenuForm).OpenAddEditOrder(order);
            }
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (this.orderDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order first!", "No order selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this order?", "Please Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result.Equals(DialogResult.Yes))
            {
                var orderId = Convert.ToInt32(this.orderDataGridView.SelectedRows[0].Cells[0].Value);
                var orderToRemove = base.Data.Orders.FirstOrDefault(x => x.OrderId == orderId);
                base.Data.Books.RemoveRange(orderToRemove.Books);
                base.Data.Orders.Remove(orderToRemove);
                base.Data.SaveChanges();

                ClearEditBookPanel();

                (this.MdiParent as MenuForm).RefreshOrders();
            }
        }

        private void ClearEditBookPanel()
        {
            this.textBoxTitle.Text = "";
            this.textBoxISBN.Text = "";
            this.textBoxOrderedCount.Text = "";
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            bool hasErrors = ValidateBooksDataGridView();

            if (hasErrors)
            {
                return;
            }

            foreach (var book in this.Books)
            {
                if (book.BookId == 0 && book.Title != null && book.ISBN != null)
                {
                    base.Data.insertBook(book.Title, book.ISBN, book.OrderedCount, this.CurrentOrderId, UserInfo.UserId);
                }
            }

            this.RefreshBooksDataGrid(this.CurrentOrderId);
        }

        private bool ValidateBooksDataGridView()
        {
            bool hasErrors = false;

            for (int i = 0; i < this.booksDataGridView.Rows.Count - 1; i++)
            {
                DataGridViewRow row = this.booksDataGridView.Rows[i];

                DataGridViewCell bookIdCell = row.Cells[booksDataGridView.Columns[0].Index];
                DataGridViewCell titleCell = row.Cells[booksDataGridView.Columns[1].Index];
                DataGridViewCell isbnCell = row.Cells[booksDataGridView.Columns[2].Index];
                DataGridViewCell orderedCountCell = row.Cells[booksDataGridView.Columns[3].Index];

                int bookId = Convert.ToInt32(bookIdCell.Value);

                if (bookId != 0)
                {
                    continue;
                }

                try
                {
                    bool isValidTitle = titleCell.Value != null && !string.IsNullOrWhiteSpace(titleCell.Value.ToString());
                    bool isValidISBN = isbnCell.Value != null && !string.IsNullOrWhiteSpace(isbnCell.Value.ToString());

                    int orderedCount;

                    bool isValidCount = int.TryParse(orderedCountCell.Value.ToString(), out orderedCount);

                    if (!isValidCount || orderedCount <= 0)
                    {
                        MessageBox.Show("OrderedCount field requires a positive integer number!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hasErrors = true;
                    }

                    if (!isValidTitle)
                    {
                        titleCell.ErrorText = "This field is required!";
                        MessageBox.Show("Title field is required!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hasErrors = true;
                    }

                    if (!isValidISBN)
                    {
                        isbnCell.ErrorText = "This field is required!";
                        MessageBox.Show("ISBN field is required!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hasErrors = true;
                    }
                }
                catch (NullReferenceException exception)
                {

                }
            }
            return hasErrors;
        }

        private void RefreshBooksDataGrid(int currentOrderId)
        {
            base.Data = new OrdersSystem.Data.OrdersEntities();
            this.order = base.Data.Orders.FirstOrDefault(x => x.OrderId == CurrentOrderId);
            this.Books = new BindingList<OrdersSystem.Data.Book>(this.order.Books.ToList());

            this.booksBindingSource.DataSource = Books;
            this.bindingNavigatorBooks.BindingSource = this.booksBindingSource;
            this.booksDataGridView.DataSource = this.booksBindingSource;
            this.booksDataGridView.Refresh();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (this.booksDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book first!", "No book selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this book?", "Please Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result.Equals(DialogResult.Yes))
            {
                var bookId = Convert.ToInt32(this.booksDataGridView.SelectedRows[0].Cells[0].Value);
                var bookToRemove = base.Data.Books.FirstOrDefault(x => x.BookId == bookId);
                base.Data.Books.Remove(bookToRemove);
                base.Data.SaveChanges();

                this.ClearEditBookPanel();

                RefreshBooksDataGrid(this.CurrentOrderId);
            }
        }

        private void booksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var bookId = Convert.ToInt32(this.booksDataGridView.SelectedRows[0].Cells[0].Value);
            refreshBookFields(bookId);
        }

        private void refreshBookFields(int bookId)
        {
            if (bookId != null && bookId != 0)
            {
                base.Data = new OrdersSystem.Data.OrdersEntities();
                this.book = base.Data.Books.FirstOrDefault(x => x.BookId == bookId);

                this.textBoxTitle.Text = book.Title;
                this.textBoxISBN.Text = book.ISBN;
                this.textBoxOrderedCount.Text = book.OrderedCount.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.titleErrorProvider.Clear();
            this.isbnErrorProvider.Clear();
            this.orderedCountErrorProvider.Clear();

            bool validTitle = base.ValidateRequiredInputField(this.titleErrorProvider, BaseForm.RequiredFieldMessage, this.textBoxTitle);
            bool validISBN = base.ValidateRequiredInputField(this.isbnErrorProvider, BaseForm.RequiredFieldMessage, this.textBoxISBN);
            bool validOrderedCount = base.ValidateRequiredInputField(this.orderedCountErrorProvider, BaseForm.RequiredFieldMessage, this.textBoxOrderedCount);

            bool hasErrors = !(validTitle && validISBN && validOrderedCount);

            int orderedCount;

            bool isCountNumber = int.TryParse(this.textBoxOrderedCount.Text, out orderedCount);

            if (!isCountNumber)
            {
                MessageBox.Show("Please enter a valid number in Ordered Count field!", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hasErrors = true;
            }

            if (!hasErrors)
            {
                var bookToUpdate = base.Data.Books.FirstOrDefault(x => x.BookId == this.book.BookId);
                bookToUpdate.Title = this.textBoxTitle.Text;
                bookToUpdate.ISBN = this.textBoxISBN.Text;
                bookToUpdate.OrderedCount = orderedCount;
                base.Data.SaveChanges();

                // to update modificationDate field, which is altered by a database trigger
                base.Data = new OrdersSystem.Data.OrdersEntities();
                bookToUpdate = base.Data.Books.FirstOrDefault(x => x.BookId == this.book.BookId);

                for (int i = 0; i < this.Books.Count; i++)
                {
                    if (this.Books[i].BookId == bookToUpdate.BookId)
                    {
                        this.Books[i] = bookToUpdate;
                        break;
                    }
                }

                this.booksDataGridView.Refresh();
            }
        }

        public void SearchOrders(string deliveryAddress, string country, DateTime modificationDate, string beforeAfter)
        {
            var queryOrders = base.Data.Orders.Where(x => x.UserId == UserInfo.UserId);

            if (!string.IsNullOrWhiteSpace(deliveryAddress))
            {
                queryOrders = queryOrders.Where(x => x.DeliveryAddress.ToLower().Equals(deliveryAddress.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(country))
            {
                queryOrders = queryOrders.Where(x => x.Country.ToLower().Equals(country.ToLower()));
            }

            if (beforeAfter.Equals("before"))
            {
                queryOrders = queryOrders.Where(x => DbFunctions.TruncateTime(x.ModificationDate) <= modificationDate);
            }
            else if (beforeAfter.Equals("after"))
            {
                queryOrders = queryOrders.Where(x => DbFunctions.TruncateTime(x.ModificationDate) >= modificationDate);
            }

            this.Orders = new BindingList<OrdersSystem.Data.Order>(queryOrders.ToList());

            this.orderBindingSource.DataSource = this.Orders;
            this.orderDataGridView.DataSource = this.orderBindingSource;
            this.orderDataGridView.Refresh();

            if (this.Orders.Count > 0)
            {
                this.order = this.Orders.First();
                this.RefreshBooksDataGrid(this.order.OrderId);
            }
            else
            {
                this.Books = new BindingList<OrdersSystem.Data.Book>();

                this.booksBindingSource.DataSource = Books;
                this.bindingNavigatorBooks.BindingSource = this.booksBindingSource;
                this.booksDataGridView.DataSource = this.booksBindingSource;
                this.booksDataGridView.Refresh();
            }
        }
        internal void SearchBooks(string title, string isbn, DateTime modificationDate, string beforeAfter)
        {
            var queryBooks = base.Data.Books.Where(x => x.UserId == UserInfo.UserId);

            if (!string.IsNullOrWhiteSpace(title))
            {
                queryBooks = queryBooks.Where(x => x.Title.ToLower().Equals(title.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(isbn))
            {
                queryBooks = queryBooks.Where(x => x.ISBN.ToLower().Equals(isbn.ToLower()));
            }

            if (beforeAfter.Equals("before"))
            {
                queryBooks = queryBooks.Where(x => DbFunctions.TruncateTime(x.ModificationDate) <= modificationDate);
            }
            else if (beforeAfter.Equals("after"))
            {
                queryBooks = queryBooks.Where(x => DbFunctions.TruncateTime(x.ModificationDate) >= modificationDate);
            }

            this.Books = new BindingList<OrdersSystem.Data.Book>(queryBooks.ToList());

            if (this.Books.Count > 0)
            {
                this.book = this.Books.First();
                this.textBoxTitle.Text = this.book.Title;
                this.textBoxISBN.Text = this.book.ISBN;
                this.textBoxOrderedCount.Text = this.book.OrderedCount.ToString();
            }

            this.booksBindingSource.DataSource = Books;
            this.bindingNavigatorBooks.BindingSource = this.booksBindingSource;
            this.booksDataGridView.DataSource = this.booksBindingSource;
            this.booksDataGridView.Refresh();
        }

        private void buttonSearchAllOrders_Click(object sender, EventArgs e)
        {
            (this.MdiParent as MenuForm).OpenOrdersSearch();
        }

        private void buttonSearchMyBooks_Click(object sender, EventArgs e)
        {
            (this.MdiParent as MenuForm).OpenBooksSearch();
        }

        private void booksDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewRow row =
                this.booksDataGridView.Rows[e.RowIndex];

            DataGridViewCell bookIdCell =
            row.Cells[booksDataGridView.Columns[0].Index];

            int bookId = Convert.ToInt32(bookIdCell.Value);

            if (bookId == 0)
            {
                DataGridViewCell titleCell = row.Cells[booksDataGridView.Columns[1].Index];
                DataGridViewCell isbnCell = row.Cells[booksDataGridView.Columns[2].Index];
                DataGridViewCell orderedCountCell = row.Cells[booksDataGridView.Columns[3].Index];

                int orderedCount;

                try
                {
                    bool isValidCount = int.TryParse(orderedCountCell.Value.ToString(), out orderedCount);

                    if (!isValidCount || orderedCount <= 0)
                    {
                        MessageBox.Show("OrderedCount field requires a positive integer number!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (NullReferenceException exception)
                {

                }
            }

            this.booksDataGridView.Refresh();
        }

    }
}