namespace SdkHarness
{
    partial class ucParameter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cmdExpand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(16, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(110, 8);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(205, 20);
            this.txtValue.TabIndex = 1;
            // 
            // cmdExpand
            // 
            this.cmdExpand.Location = new System.Drawing.Point(110, 6);
            this.cmdExpand.Name = "cmdExpand";
            this.cmdExpand.Size = new System.Drawing.Size(31, 23);
            this.cmdExpand.TabIndex = 2;
            this.cmdExpand.Text = "...";
            this.cmdExpand.UseVisualStyleBackColor = true;
            this.cmdExpand.Visible = false;
            this.cmdExpand.Click += new System.EventHandler(this.cmdExpand_Click);
            // 
            // ucParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdExpand);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblName);
            this.Name = "ucParameter";
            this.Size = new System.Drawing.Size(336, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button cmdExpand;
    }
}
