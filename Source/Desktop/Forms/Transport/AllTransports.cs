using Desktop.Forms.Common;
using Desktop.Forms.Identity;
using Desktop.Forms.Order;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Desktop.Forms.Transport
{
    public partial class AllTransports : BaseForm
    {
        private const string ExistingTransportMessage = "Transport for this date already exists";

        public ErrorProvider TransportDateErrorProvider { get; set; }

        public AllTransports()
        {
            this.TransportDateErrorProvider = new ErrorProvider();
            InitializeComponent();
            this.dataGridViewTransports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.dataGridViewTransports.DataSource = base.Data.Transports.ToList();
        }

        private void buttonAddNewTransport_Click(object sender, EventArgs e)
        {
            this.TransportDateErrorProvider.Clear();

            DateTime transportDate = this.dateTimePickerNewTransport.Value.Date;

            var existing = base.Data.Transports.FirstOrDefault(x =>
                x.StartOffDate.Equals(transportDate));

            if (existing != null)
            {
                this.TransportDateErrorProvider.SetError(this.dateTimePickerNewTransport, ExistingTransportMessage);
                return;
            }

            this.Data.insertTransport(transportDate);

            this.dataGridViewTransports.DataSource = this.Data.Transports.ToList();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DateTime searchDate = this.dateTimePickerSearch.Value.Date;

            int compareToValue = this.comboBoxBeforeAfter.SelectedItem.ToString().Equals("before") ? -1 : 1;

            this.dataGridViewTransports.DataSource = base.Data.Transports.
                Where(x =>
                x.StartOffDate.CompareTo(searchDate) == 0 ||
                x.StartOffDate.CompareTo(searchDate) == compareToValue)
                .ToList();
        }

        private void toolStripMenuItemOrders_Click(object sender, EventArgs e)
        {
            int transportId = Convert.ToInt32(this.dataGridViewTransports.SelectedRows[0].Cells[0].Value);
            UserInfo.CurrentTransportId = transportId;

            (this.MdiParent as MenuForm).OpenOrdersAndBooks();
        }
    }
}
