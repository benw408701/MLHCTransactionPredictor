namespace MLHCTransactionPredictor
{
    partial class frmTest
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
            this.lblCoverageType = new System.Windows.Forms.Label();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.lblLoanAmount = new System.Windows.Forms.Label();
            this.lblLiens = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCoverageType
            // 
            this.lblCoverageType.AutoSize = true;
            this.lblCoverageType.Location = new System.Drawing.Point(13, 13);
            this.lblCoverageType.Name = "lblCoverageType";
            this.lblCoverageType.Size = new System.Drawing.Size(83, 13);
            this.lblCoverageType.TabIndex = 0;
            this.lblCoverageType.Text = "Coverage Type:";
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Location = new System.Drawing.Point(12, 40);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(93, 13);
            this.lblTransactionType.TabIndex = 1;
            this.lblTransactionType.Text = "Transaction Type:";
            // 
            // lblLoanAmount
            // 
            this.lblLoanAmount.AutoSize = true;
            this.lblLoanAmount.Location = new System.Drawing.Point(12, 67);
            this.lblLoanAmount.Name = "lblLoanAmount";
            this.lblLoanAmount.Size = new System.Drawing.Size(73, 13);
            this.lblLoanAmount.TabIndex = 2;
            this.lblLoanAmount.Text = "Loan Amount:";
            // 
            // lblLiens
            // 
            this.lblLiens.AutoSize = true;
            this.lblLiens.Location = new System.Drawing.Point(16, 98);
            this.lblLiens.Name = "lblLiens";
            this.lblLiens.Size = new System.Drawing.Size(35, 13);
            this.lblLiens.TabIndex = 3;
            this.lblLiens.Text = "label1";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 307);
            this.Controls.Add(this.lblLiens);
            this.Controls.Add(this.lblLoanAmount);
            this.Controls.Add(this.lblTransactionType);
            this.Controls.Add(this.lblCoverageType);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCoverageType;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.Label lblLoanAmount;
        private System.Windows.Forms.Label lblLiens;
    }
}