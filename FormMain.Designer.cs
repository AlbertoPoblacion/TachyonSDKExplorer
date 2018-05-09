namespace SdkHarness
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lblAPI = new System.Windows.Forms.Label();
            this.cmbAPI = new System.Windows.Forms.ComboBox();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.gbParameters = new System.Windows.Forms.GroupBox();
            this.pnlParameters = new System.Windows.Forms.Panel();
            this.cmdOk = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtTachyonUrl = new System.Windows.Forms.TextBox();
            this.lblConsumerUrl = new System.Windows.Forms.Label();
            this.txtConsumerName = new System.Windows.Forms.TextBox();
            this.lblConsumerName = new System.Windows.Forms.Label();
            this.gbParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAPI
            // 
            this.lblAPI.AutoSize = true;
            this.lblAPI.Location = new System.Drawing.Point(21, 118);
            this.lblAPI.Name = "lblAPI";
            this.lblAPI.Size = new System.Drawing.Size(27, 13);
            this.lblAPI.TabIndex = 4;
            this.lblAPI.Text = "API:";
            // 
            // cmbAPI
            // 
            this.cmbAPI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAPI.FormattingEnabled = true;
            this.cmbAPI.Location = new System.Drawing.Point(87, 115);
            this.cmbAPI.Name = "cmbAPI";
            this.cmbAPI.Size = new System.Drawing.Size(401, 21);
            this.cmbAPI.TabIndex = 5;
            this.cmbAPI.SelectedIndexChanged += new System.EventHandler(this.cmbAPI_SelectedIndexChanged);
            // 
            // cmbMethod
            // 
            this.cmbMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Location = new System.Drawing.Point(87, 161);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(401, 21);
            this.cmbMethod.TabIndex = 7;
            this.cmbMethod.SelectedIndexChanged += new System.EventHandler(this.cmbMethod_SelectedIndexChanged);
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(21, 164);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(46, 13);
            this.lblMethod.TabIndex = 6;
            this.lblMethod.Text = "Method:";
            // 
            // gbParameters
            // 
            this.gbParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbParameters.Controls.Add(this.pnlParameters);
            this.gbParameters.Location = new System.Drawing.Point(26, 202);
            this.gbParameters.Name = "gbParameters";
            this.gbParameters.Size = new System.Drawing.Size(474, 171);
            this.gbParameters.TabIndex = 8;
            this.gbParameters.TabStop = false;
            this.gbParameters.Text = "Parameters";
            // 
            // pnlParameters
            // 
            this.pnlParameters.AutoScroll = true;
            this.pnlParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParameters.Location = new System.Drawing.Point(3, 16);
            this.pnlParameters.Name = "pnlParameters";
            this.pnlParameters.Size = new System.Drawing.Size(468, 152);
            this.pnlParameters.TabIndex = 0;
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOk.Location = new System.Drawing.Point(344, 379);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 9;
            this.cmdOk.Text = "&Send";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(425, 379);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "&Close";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtTachyonUrl
            // 
            this.txtTachyonUrl.Location = new System.Drawing.Point(12, 71);
            this.txtTachyonUrl.Name = "txtTachyonUrl";
            this.txtTachyonUrl.Size = new System.Drawing.Size(272, 20);
            this.txtTachyonUrl.TabIndex = 3;
            this.txtTachyonUrl.Text = "http://localhost/Consumer";
            // 
            // lblConsumerUrl
            // 
            this.lblConsumerUrl.AutoSize = true;
            this.lblConsumerUrl.Location = new System.Drawing.Point(12, 55);
            this.lblConsumerUrl.Name = "lblConsumerUrl";
            this.lblConsumerUrl.Size = new System.Drawing.Size(123, 13);
            this.lblConsumerUrl.TabIndex = 2;
            this.lblConsumerUrl.Text = "Tachyon consumer URL";
            // 
            // txtConsumerName
            // 
            this.txtConsumerName.Location = new System.Drawing.Point(12, 32);
            this.txtConsumerName.Name = "txtConsumerName";
            this.txtConsumerName.Size = new System.Drawing.Size(153, 20);
            this.txtConsumerName.TabIndex = 1;
            this.txtConsumerName.Text = "Explorer";
            // 
            // lblConsumerName
            // 
            this.lblConsumerName.AutoSize = true;
            this.lblConsumerName.Location = new System.Drawing.Point(12, 16);
            this.lblConsumerName.Name = "lblConsumerName";
            this.lblConsumerName.Size = new System.Drawing.Size(331, 13);
            this.lblConsumerName.TabIndex = 0;
            this.lblConsumerName.Text = "Consumer Name (must match the name that is registered in Tachyon)";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(525, 414);
            this.Controls.Add(this.txtTachyonUrl);
            this.Controls.Add(this.lblConsumerUrl);
            this.Controls.Add(this.txtConsumerName);
            this.Controls.Add(this.lblConsumerName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.gbParameters);
            this.Controls.Add(this.cmbMethod);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.cmbAPI);
            this.Controls.Add(this.lblAPI);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(541, 410);
            this.Name = "FormMain";
            this.Text = "Tachyon SDK Test Harness";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.gbParameters.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAPI;
        private System.Windows.Forms.ComboBox cmbAPI;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.GroupBox gbParameters;
        private System.Windows.Forms.Panel pnlParameters;
        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtTachyonUrl;
        private System.Windows.Forms.Label lblConsumerUrl;
        private System.Windows.Forms.TextBox txtConsumerName;
        private System.Windows.Forms.Label lblConsumerName;
    }
}

