namespace Desktop.Forms.Search
{
    partial class SearchMyBooks
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelISBN = new System.Windows.Forms.Label();
            this.labelModificationDate = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxISBN = new System.Windows.Forms.TextBox();
            this.dateTimePickerModificationDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxBeforeAfter = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.toolTipTitle = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipISBN = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipModificationDate = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(12, 30);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(59, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title:";
            // 
            // labelISBN
            // 
            this.labelISBN.AutoSize = true;
            this.labelISBN.Location = new System.Drawing.Point(12, 80);
            this.labelISBN.Name = "labelISBN";
            this.labelISBN.Size = new System.Drawing.Size(66, 25);
            this.labelISBN.TabIndex = 0;
            this.labelISBN.Text = "ISBN:";
            // 
            // labelModificationDate
            // 
            this.labelModificationDate.AutoSize = true;
            this.labelModificationDate.Location = new System.Drawing.Point(8, 138);
            this.labelModificationDate.Name = "labelModificationDate";
            this.labelModificationDate.Size = new System.Drawing.Size(185, 25);
            this.labelModificationDate.TabIndex = 0;
            this.labelModificationDate.Text = "Modification Date:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(217, 30);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(200, 31);
            this.textBoxTitle.TabIndex = 4;
            this.toolTipTitle.SetToolTip(textBoxTitle, "Search books by title");
            // 
            // textBoxISBN
            // 
            this.textBoxISBN.Location = new System.Drawing.Point(217, 80);
            this.textBoxISBN.Name = "textBoxISBN";
            this.textBoxISBN.Size = new System.Drawing.Size(200, 31);
            this.textBoxISBN.TabIndex = 5;
            this.toolTipISBN.SetToolTip(textBoxISBN, "Search books by ISBN number");
            // 
            // dateTimePickerModificationDate
            // 
            this.dateTimePickerModificationDate.Location = new System.Drawing.Point(217, 138);
            this.dateTimePickerModificationDate.Name = "dateTimePickerModificationDate";
            this.dateTimePickerModificationDate.Size = new System.Drawing.Size(200, 31);
            this.dateTimePickerModificationDate.TabIndex = 3;
            this.toolTipModificationDate.SetToolTip(dateTimePickerModificationDate, "Search books by last modification date");
            // 
            // comboBoxBeforeAfter
            // 
            this.comboBoxBeforeAfter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBeforeAfter.FormattingEnabled = true;
            this.comboBoxBeforeAfter.Items.AddRange(new object[] {
            "any",
            "before",
            "after"});
            this.comboBoxBeforeAfter.Location = new System.Drawing.Point(437, 140);
            this.comboBoxBeforeAfter.Name = "comboBoxBeforeAfter";
            this.comboBoxBeforeAfter.Size = new System.Drawing.Size(121, 33);
            this.comboBoxBeforeAfter.TabIndex = 4;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonSearch.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSearch.Location = new System.Drawing.Point(453, 215);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(105, 35);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // SearchMyBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 288);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.comboBoxBeforeAfter);
            this.Controls.Add(this.dateTimePickerModificationDate);
            this.Controls.Add(this.textBoxISBN);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelModificationDate);
            this.Controls.Add(this.labelISBN);
            this.Controls.Add(this.labelTitle);
            this.Name = "SearchMyBooks";
            this.Text = "SearchMyBooks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelISBN;
        private System.Windows.Forms.Label labelModificationDate;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxISBN;
        private System.Windows.Forms.DateTimePicker dateTimePickerModificationDate;
        private System.Windows.Forms.ComboBox comboBoxBeforeAfter;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ToolTip toolTipTitle;
        private System.Windows.Forms.ToolTip toolTipISBN;
        private System.Windows.Forms.ToolTip toolTipModificationDate;
    }
}