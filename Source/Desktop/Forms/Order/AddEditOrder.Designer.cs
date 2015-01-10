namespace Desktop.Forms.Order
{
    partial class AddEditOrder
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
            this.labelDeliveryAddress = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.textBoxDeliveryAddress = new System.Windows.Forms.TextBox();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.toolTipDeliveryAddress = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipCountry = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelDeliveryAddress
            // 
            this.labelDeliveryAddress.AutoSize = true;
            this.labelDeliveryAddress.Location = new System.Drawing.Point(0, 27);
            this.labelDeliveryAddress.Name = "labelDeliveryAddress";
            this.labelDeliveryAddress.Size = new System.Drawing.Size(181, 25);
            this.labelDeliveryAddress.TabIndex = 0;
            this.labelDeliveryAddress.Text = "Delivery Address:";
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Location = new System.Drawing.Point(0, 96);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(93, 25);
            this.labelCountry.TabIndex = 1;
            this.labelCountry.Text = "Country:";
            // 
            // textBoxDeliveryAddress
            // 
            this.textBoxDeliveryAddress.Location = new System.Drawing.Point(187, 27);
            this.textBoxDeliveryAddress.Name = "textBoxDeliveryAddress";
            this.textBoxDeliveryAddress.Size = new System.Drawing.Size(192, 31);
            this.textBoxDeliveryAddress.TabIndex = 1;
            this.toolTipDeliveryAddress.SetToolTip(textBoxDeliveryAddress, "Address where the order will be delivered");
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Location = new System.Drawing.Point(187, 90);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(192, 31);
            this.textBoxCountry.TabIndex = 2;
            this.toolTipCountry.SetToolTip(textBoxCountry, "Country in which the order will be delivered");
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonOK.Location = new System.Drawing.Point(187, 162);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(77, 36);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCancel.Location = new System.Drawing.Point(282, 162);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(97, 36);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AddEditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 236);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxCountry);
            this.Controls.Add(this.textBoxDeliveryAddress);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.labelDeliveryAddress);
            this.Name = "AddEditOrder";
            this.Text = "AddEditOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDeliveryAddress;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.TextBox textBoxDeliveryAddress;
        private System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ToolTip toolTipDeliveryAddress;
        private System.Windows.Forms.ToolTip toolTipCountry;
    }
}