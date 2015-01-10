namespace Desktop.Forms.Search
{
    partial class SearchMyOrders
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxDeliveryAddress = new System.Windows.Forms.TextBox();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.dateTimePickerModificationDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxBeforeAfter = new System.Windows.Forms.ComboBox();
            this.labelModificationDate = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelDeliveryAddress = new System.Windows.Forms.Label();
            this.toolTipDeliveryAddress = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipCountry = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipModificationDate = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonSearch.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSearch.Location = new System.Drawing.Point(444, 227);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(105, 35);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxDeliveryAddress
            // 
            this.textBoxDeliveryAddress.Location = new System.Drawing.Point(203, 49);
            this.textBoxDeliveryAddress.Name = "textBoxDeliveryAddress";
            this.textBoxDeliveryAddress.Size = new System.Drawing.Size(200, 31);
            this.textBoxDeliveryAddress.TabIndex = 1;
            this.toolTipDeliveryAddress.SetToolTip(textBoxDeliveryAddress, "Search by order delivery address");
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Location = new System.Drawing.Point(203, 106);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(200, 31);
            this.textBoxCountry.TabIndex = 2;
            this.toolTipCountry.SetToolTip(textBoxCountry, "Search by order shipment country");
            // 
            // dateTimePickerModificationDate
            // 
            this.dateTimePickerModificationDate.Location = new System.Drawing.Point(203, 167);
            this.dateTimePickerModificationDate.Name = "dateTimePickerModificationDate";
            this.dateTimePickerModificationDate.Size = new System.Drawing.Size(200, 31);
            this.dateTimePickerModificationDate.TabIndex = 3;
            this.toolTipModificationDate.SetToolTip(dateTimePickerModificationDate, "Search by order last modification date");
            // 
            // comboBoxBeforeAfter
            // 
            this.comboBoxBeforeAfter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBeforeAfter.FormattingEnabled = true;
            this.comboBoxBeforeAfter.Items.AddRange(new object[] {
            "any",
            "before",
            "after"});
            this.comboBoxBeforeAfter.Location = new System.Drawing.Point(428, 165);
            this.comboBoxBeforeAfter.Name = "comboBoxBeforeAfter";
            this.comboBoxBeforeAfter.Size = new System.Drawing.Size(121, 33);
            this.comboBoxBeforeAfter.TabIndex = 4;
            // 
            // labelModificationDate
            // 
            this.labelModificationDate.AutoSize = true;
            this.labelModificationDate.Location = new System.Drawing.Point(12, 173);
            this.labelModificationDate.Name = "labelModificationDate";
            this.labelModificationDate.Size = new System.Drawing.Size(185, 25);
            this.labelModificationDate.TabIndex = 0;
            this.labelModificationDate.Text = "Modification Date:";
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Location = new System.Drawing.Point(12, 106);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(93, 25);
            this.labelCountry.TabIndex = 0;
            this.labelCountry.Text = "Country:";
            // 
            // labelDeliveryAddress
            // 
            this.labelDeliveryAddress.AutoSize = true;
            this.labelDeliveryAddress.Location = new System.Drawing.Point(12, 49);
            this.labelDeliveryAddress.Name = "labelDeliveryAddress";
            this.labelDeliveryAddress.Size = new System.Drawing.Size(181, 25);
            this.labelDeliveryAddress.TabIndex = 0;
            this.labelDeliveryAddress.Text = "Delivery Address:";
            // 
            // SearchMyOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 291);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxDeliveryAddress);
            this.Controls.Add(this.textBoxCountry);
            this.Controls.Add(this.dateTimePickerModificationDate);
            this.Controls.Add(this.comboBoxBeforeAfter);
            this.Controls.Add(this.labelModificationDate);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.labelDeliveryAddress);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SearchMyOrders";
            this.Text = "SearchMyOrders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDeliveryAddress;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Label labelModificationDate;
        private System.Windows.Forms.ComboBox comboBoxBeforeAfter;
        private System.Windows.Forms.DateTimePicker dateTimePickerModificationDate;
        private System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.TextBox textBoxDeliveryAddress;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ToolTip toolTipDeliveryAddress;
        private System.Windows.Forms.ToolTip toolTipCountry;
        private System.Windows.Forms.ToolTip toolTipModificationDate;
    }
}