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
            this.lblActions = new System.Windows.Forms.Label();
            this.lblAuditEntries = new System.Windows.Forms.Label();
            this.lblNotesLoged = new System.Windows.Forms.Label();
            this.cmbCoverageType = new System.Windows.Forms.ComboBox();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.trkLoanAmount = new System.Windows.Forms.TrackBar();
            this.txtLoanAmount = new System.Windows.Forms.TextBox();
            this.trkLiens = new System.Windows.Forms.TrackBar();
            this.txtLiens = new System.Windows.Forms.TextBox();
            this.trkActions = new System.Windows.Forms.TrackBar();
            this.txtActions = new System.Windows.Forms.TextBox();
            this.trkAuditEntries = new System.Windows.Forms.TrackBar();
            this.txtAuditEntries = new System.Windows.Forms.TextBox();
            this.trkNotesLogged = new System.Windows.Forms.TrackBar();
            this.txtNotesLogged = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trkLoanAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkLiens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAuditEntries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkNotesLogged)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCoverageType
            // 
            this.lblCoverageType.AutoSize = true;
            this.lblCoverageType.Location = new System.Drawing.Point(16, 13);
            this.lblCoverageType.Name = "lblCoverageType";
            this.lblCoverageType.Size = new System.Drawing.Size(83, 13);
            this.lblCoverageType.TabIndex = 0;
            this.lblCoverageType.Text = "Coverage Type:";
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Location = new System.Drawing.Point(16, 41);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(93, 13);
            this.lblTransactionType.TabIndex = 1;
            this.lblTransactionType.Text = "Transaction Type:";
            // 
            // lblLoanAmount
            // 
            this.lblLoanAmount.AutoSize = true;
            this.lblLoanAmount.Location = new System.Drawing.Point(16, 69);
            this.lblLoanAmount.Name = "lblLoanAmount";
            this.lblLoanAmount.Size = new System.Drawing.Size(73, 13);
            this.lblLoanAmount.TabIndex = 2;
            this.lblLoanAmount.Text = "Loan Amount:";
            // 
            // lblLiens
            // 
            this.lblLiens.AutoSize = true;
            this.lblLiens.Location = new System.Drawing.Point(16, 157);
            this.lblLiens.Name = "lblLiens";
            this.lblLiens.Size = new System.Drawing.Size(35, 13);
            this.lblLiens.TabIndex = 3;
            this.lblLiens.Text = "Liens:";
            // 
            // lblActions
            // 
            this.lblActions.AutoSize = true;
            this.lblActions.Location = new System.Drawing.Point(16, 245);
            this.lblActions.Name = "lblActions";
            this.lblActions.Size = new System.Drawing.Size(45, 13);
            this.lblActions.TabIndex = 4;
            this.lblActions.Text = "Actions:";
            // 
            // lblAuditEntries
            // 
            this.lblAuditEntries.AutoSize = true;
            this.lblAuditEntries.Location = new System.Drawing.Point(265, 69);
            this.lblAuditEntries.Name = "lblAuditEntries";
            this.lblAuditEntries.Size = new System.Drawing.Size(113, 13);
            this.lblAuditEntries.TabIndex = 5;
            this.lblAuditEntries.Text = "Audit Entries (per day):";
            // 
            // lblNotesLoged
            // 
            this.lblNotesLoged.AutoSize = true;
            this.lblNotesLoged.Location = new System.Drawing.Point(265, 157);
            this.lblNotesLoged.Name = "lblNotesLoged";
            this.lblNotesLoged.Size = new System.Drawing.Size(121, 13);
            this.lblNotesLoged.TabIndex = 6;
            this.lblNotesLoged.Text = "Notes Logged (per day):";
            // 
            // cmbCoverageType
            // 
            this.cmbCoverageType.FormattingEnabled = true;
            this.cmbCoverageType.Location = new System.Drawing.Point(124, 10);
            this.cmbCoverageType.Name = "cmbCoverageType";
            this.cmbCoverageType.Size = new System.Drawing.Size(121, 21);
            this.cmbCoverageType.TabIndex = 7;
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Location = new System.Drawing.Point(124, 38);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(121, 21);
            this.cmbTransactionType.TabIndex = 8;
            // 
            // trkLoanAmount
            // 
            this.trkLoanAmount.Location = new System.Drawing.Point(16, 97);
            this.trkLoanAmount.Name = "trkLoanAmount";
            this.trkLoanAmount.Size = new System.Drawing.Size(229, 45);
            this.trkLoanAmount.TabIndex = 10;
            this.trkLoanAmount.Scroll += new System.EventHandler(this.trkLoanAmount_Scroll);
            // 
            // txtLoanAmount
            // 
            this.txtLoanAmount.Location = new System.Drawing.Point(124, 66);
            this.txtLoanAmount.Name = "txtLoanAmount";
            this.txtLoanAmount.Size = new System.Drawing.Size(121, 20);
            this.txtLoanAmount.TabIndex = 11;
            this.txtLoanAmount.TextChanged += new System.EventHandler(this.txtLoanAmount_TextChanged);
            // 
            // trkLiens
            // 
            this.trkLiens.Location = new System.Drawing.Point(16, 185);
            this.trkLiens.Name = "trkLiens";
            this.trkLiens.Size = new System.Drawing.Size(229, 45);
            this.trkLiens.TabIndex = 12;
            this.trkLiens.Scroll += new System.EventHandler(this.trkLiens_Scroll);
            // 
            // txtLiens
            // 
            this.txtLiens.Location = new System.Drawing.Point(124, 154);
            this.txtLiens.Name = "txtLiens";
            this.txtLiens.Size = new System.Drawing.Size(121, 20);
            this.txtLiens.TabIndex = 13;
            this.txtLiens.TextChanged += new System.EventHandler(this.txtLiens_TextChanged);
            // 
            // trkActions
            // 
            this.trkActions.Location = new System.Drawing.Point(16, 273);
            this.trkActions.Name = "trkActions";
            this.trkActions.Size = new System.Drawing.Size(229, 45);
            this.trkActions.TabIndex = 14;
            this.trkActions.Scroll += new System.EventHandler(this.trkActions_Scroll);
            // 
            // txtActions
            // 
            this.txtActions.Location = new System.Drawing.Point(124, 242);
            this.txtActions.Name = "txtActions";
            this.txtActions.Size = new System.Drawing.Size(121, 20);
            this.txtActions.TabIndex = 15;
            this.txtActions.TextChanged += new System.EventHandler(this.txtActions_TextChanged);
            // 
            // trkAuditEntries
            // 
            this.trkAuditEntries.Location = new System.Drawing.Point(268, 97);
            this.trkAuditEntries.Name = "trkAuditEntries";
            this.trkAuditEntries.Size = new System.Drawing.Size(242, 45);
            this.trkAuditEntries.TabIndex = 16;
            this.trkAuditEntries.Scroll += new System.EventHandler(this.trkAuditEntries_Scroll);
            // 
            // txtAuditEntries
            // 
            this.txtAuditEntries.Location = new System.Drawing.Point(389, 66);
            this.txtAuditEntries.Name = "txtAuditEntries";
            this.txtAuditEntries.Size = new System.Drawing.Size(121, 20);
            this.txtAuditEntries.TabIndex = 17;
            this.txtAuditEntries.TextChanged += new System.EventHandler(this.txtAuditEntries_TextChanged);
            // 
            // trkNotesLogged
            // 
            this.trkNotesLogged.Location = new System.Drawing.Point(268, 185);
            this.trkNotesLogged.Name = "trkNotesLogged";
            this.trkNotesLogged.Size = new System.Drawing.Size(242, 45);
            this.trkNotesLogged.TabIndex = 18;
            this.trkNotesLogged.Scroll += new System.EventHandler(this.trkNotesLogged_Scroll);
            // 
            // txtNotesLogged
            // 
            this.txtNotesLogged.Location = new System.Drawing.Point(389, 157);
            this.txtNotesLogged.Name = "txtNotesLogged";
            this.txtNotesLogged.Size = new System.Drawing.Size(121, 20);
            this.txtNotesLogged.TabIndex = 19;
            this.txtNotesLogged.TextChanged += new System.EventHandler(this.txtNotesLogged_TextChanged);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 391);
            this.Controls.Add(this.txtNotesLogged);
            this.Controls.Add(this.trkNotesLogged);
            this.Controls.Add(this.txtAuditEntries);
            this.Controls.Add(this.trkAuditEntries);
            this.Controls.Add(this.txtActions);
            this.Controls.Add(this.trkActions);
            this.Controls.Add(this.txtLiens);
            this.Controls.Add(this.trkLiens);
            this.Controls.Add(this.txtLoanAmount);
            this.Controls.Add(this.trkLoanAmount);
            this.Controls.Add(this.cmbTransactionType);
            this.Controls.Add(this.cmbCoverageType);
            this.Controls.Add(this.lblNotesLoged);
            this.Controls.Add(this.lblAuditEntries);
            this.Controls.Add(this.lblActions);
            this.Controls.Add(this.lblLiens);
            this.Controls.Add(this.lblLoanAmount);
            this.Controls.Add(this.lblTransactionType);
            this.Controls.Add(this.lblCoverageType);
            this.Name = "frmTest";
            this.Text = "Test Network";
            ((System.ComponentModel.ISupportInitialize)(this.trkLoanAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkLiens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAuditEntries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkNotesLogged)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCoverageType;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.Label lblLoanAmount;
        private System.Windows.Forms.Label lblLiens;
        private System.Windows.Forms.Label lblActions;
        private System.Windows.Forms.Label lblAuditEntries;
        private System.Windows.Forms.Label lblNotesLoged;
        private System.Windows.Forms.ComboBox cmbCoverageType;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.TrackBar trkLoanAmount;
        private System.Windows.Forms.TextBox txtLoanAmount;
        private System.Windows.Forms.TrackBar trkLiens;
        private System.Windows.Forms.TextBox txtLiens;
        private System.Windows.Forms.TrackBar trkActions;
        private System.Windows.Forms.TextBox txtActions;
        private System.Windows.Forms.TrackBar trkAuditEntries;
        private System.Windows.Forms.TextBox txtAuditEntries;
        private System.Windows.Forms.TrackBar trkNotesLogged;
        private System.Windows.Forms.TextBox txtNotesLogged;
    }
}