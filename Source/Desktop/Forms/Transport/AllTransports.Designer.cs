﻿using System.Windows.Forms;
namespace Desktop.Forms.Transport
{
    partial class AllTransports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonAddNewTransport = new System.Windows.Forms.Button();
            this.dateTimePickerNewTransport = new System.Windows.Forms.DateTimePicker();
            this.toolTipNewTransport = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewTransports = new System.Windows.Forms.DataGridView();
            this.transportIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startOffDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modificationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripOrders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.transportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transportsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxBeforeAfter = new System.Windows.Forms.ComboBox();
            this.dateTimePickerSearch = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransports)).BeginInit();
            this.contextMenuStripOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportsDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddNewTransport
            // 
            this.buttonAddNewTransport.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAddNewTransport.Location = new System.Drawing.Point(435, 12);
            this.buttonAddNewTransport.Name = "buttonAddNewTransport";
            this.buttonAddNewTransport.Size = new System.Drawing.Size(113, 38);
            this.buttonAddNewTransport.TabIndex = 0;
            this.buttonAddNewTransport.Text = "Add New";
            this.buttonAddNewTransport.UseVisualStyleBackColor = false;
            this.buttonAddNewTransport.Click += new System.EventHandler(this.buttonAddNewTransport_Click);
            // 
            // dateTimePickerNewTransport
            // 
            this.dateTimePickerNewTransport.Location = new System.Drawing.Point(12, 12);
            this.dateTimePickerNewTransport.Name = "dateTimePickerNewTransport";
            this.dateTimePickerNewTransport.Size = new System.Drawing.Size(252, 31);
            this.dateTimePickerNewTransport.TabIndex = 1;
            this.toolTipNewTransport.SetToolTip(this.dateTimePickerNewTransport, "Shipment day");
            // 
            // toolTipNewTransport
            // 
            this.toolTipNewTransport.ToolTipTitle = "Transport Date";
            // 
            // dataGridViewTransports
            // 
            this.dataGridViewTransports.AllowUserToDeleteRows = false;
            this.dataGridViewTransports.AutoGenerateColumns = false;
            this.dataGridViewTransports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transportIdDataGridViewTextBoxColumn,
            this.startOffDateDataGridViewTextBoxColumn,
            this.modificationDateDataGridViewTextBoxColumn});
            this.dataGridViewTransports.ContextMenuStrip = this.contextMenuStripOrders;
            this.dataGridViewTransports.DataSource = this.transportBindingSource;
            this.dataGridViewTransports.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridViewTransports.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewTransports.Location = new System.Drawing.Point(12, 166);
            this.dataGridViewTransports.Name = "dataGridViewTransports";
            this.dataGridViewTransports.ReadOnly = true;
            this.dataGridViewTransports.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewTransports.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewTransports.Size = new System.Drawing.Size(536, 216);
            this.dataGridViewTransports.TabIndex = 2;
            this.dataGridViewTransports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTransports.MultiSelect = false;
            // 
            // transportIdDataGridViewTextBoxColumn
            // 
            this.transportIdDataGridViewTextBoxColumn.DataPropertyName = "TransportId";
            this.transportIdDataGridViewTextBoxColumn.HeaderText = "TransportId";
            this.transportIdDataGridViewTextBoxColumn.Name = "transportIdDataGridViewTextBoxColumn";
            this.transportIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startOffDateDataGridViewTextBoxColumn
            // 
            this.startOffDateDataGridViewTextBoxColumn.DataPropertyName = "StartOffDate";
            this.startOffDateDataGridViewTextBoxColumn.HeaderText = "StartOffDate";
            this.startOffDateDataGridViewTextBoxColumn.Name = "startOffDateDataGridViewTextBoxColumn";
            this.startOffDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modificationDateDataGridViewTextBoxColumn
            // 
            this.modificationDateDataGridViewTextBoxColumn.DataPropertyName = "ModificationDate";
            this.modificationDateDataGridViewTextBoxColumn.HeaderText = "CreationDate";
            this.modificationDateDataGridViewTextBoxColumn.Name = "modificationDateDataGridViewTextBoxColumn";
            this.modificationDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contextMenuStripOrders
            // 
            this.contextMenuStripOrders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOrders});
            this.contextMenuStripOrders.Name = "contextMenuStripOrders";
            this.contextMenuStripOrders.Size = new System.Drawing.Size(153, 48);
            
            // 
            // toolStripMenuItemOrders
            // 
            this.toolStripMenuItemOrders.Name = "toolStripMenuItemOrders";
            this.toolStripMenuItemOrders.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemOrders.Text = "Orders";
            this.toolStripMenuItemOrders.ToolTipText = "Open my orders for transport.";
            this.toolStripMenuItemOrders.Click += new System.EventHandler(this.toolStripMenuItemOrders_Click);
            // 
            // transportBindingSource
            // 
            this.transportBindingSource.DataSource = typeof(OrdersSystem.Data.Transport);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonSearch.Location = new System.Drawing.Point(435, 74);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(113, 38);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxBeforeAfter
            // 
            this.comboBoxBeforeAfter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBeforeAfter.FormattingEnabled = true;
            this.comboBoxBeforeAfter.Items.AddRange(new object[] {
            "before",
            "after"});
            this.comboBoxBeforeAfter.Location = new System.Drawing.Point(308, 78);
            this.comboBoxBeforeAfter.Name = "comboBoxBeforeAfter";
            this.comboBoxBeforeAfter.Size = new System.Drawing.Size(121, 33);
            this.comboBoxBeforeAfter.TabIndex = 4;
            this.comboBoxBeforeAfter.SelectedIndex = 0;
            // 
            // dateTimePickerSearch
            // 
            this.dateTimePickerSearch.Location = new System.Drawing.Point(12, 81);
            this.dateTimePickerSearch.Name = "dateTimePickerSearch";
            this.dateTimePickerSearch.Size = new System.Drawing.Size(252, 31);
            this.dateTimePickerSearch.TabIndex = 6;
            // 
            // AllTransports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 478);
            this.Controls.Add(this.dateTimePickerSearch);
            this.Controls.Add(this.comboBoxBeforeAfter);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dataGridViewTransports);
            this.Controls.Add(this.dateTimePickerNewTransport);
            this.Controls.Add(this.buttonAddNewTransport);
            this.Name = "AllTransports";
            this.Text = "AllTransports";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransports)).EndInit();
            this.contextMenuStripOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.transportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportsDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddNewTransport;
        private System.Windows.Forms.DateTimePicker dateTimePickerNewTransport;
        private System.Windows.Forms.ToolTip toolTipNewTransport;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dataGridViewTransports;
        private System.Windows.Forms.BindingSource transportsDataSetBindingSource;
        private System.Windows.Forms.BindingSource transportBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn transportIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startOffDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modificationDateDataGridViewTextBoxColumn;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBoxBeforeAfter;
        private System.Windows.Forms.DateTimePicker dateTimePickerSearch;
        private ContextMenuStrip contextMenuStripOrders;
        private ToolStripMenuItem toolStripMenuItemOrders;
    }
}