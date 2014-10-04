namespace MLHCTransactionPredictor
{
    partial class frmMain
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
            this.txtMain = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.btnCreateNeuralNet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMain
            // 
            this.txtMain.Location = new System.Drawing.Point(12, 80);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMain.Size = new System.Drawing.Size(1032, 363);
            this.txtMain.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(109, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(127, 41);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(109, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(12, 41);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(109, 23);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process Data";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnPopulate
            // 
            this.btnPopulate.Location = new System.Drawing.Point(127, 12);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(109, 23);
            this.btnPopulate.TabIndex = 5;
            this.btnPopulate.Text = "Populate Display";
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // btnCreateNeuralNet
            // 
            this.btnCreateNeuralNet.Location = new System.Drawing.Point(242, 12);
            this.btnCreateNeuralNet.Name = "btnCreateNeuralNet";
            this.btnCreateNeuralNet.Size = new System.Drawing.Size(109, 23);
            this.btnCreateNeuralNet.TabIndex = 6;
            this.btnCreateNeuralNet.Text = "Create Neural Net";
            this.btnCreateNeuralNet.UseVisualStyleBackColor = true;
            this.btnCreateNeuralNet.Click += new System.EventHandler(this.btnCreateNeuralNet_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 455);
            this.Controls.Add(this.btnCreateNeuralNet);
            this.Controls.Add(this.btnPopulate);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtMain);
            this.Name = "frmMain";
            this.Text = "MLHC Transaction Predictor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMain;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnPopulate;
        private System.Windows.Forms.Button btnCreateNeuralNet;
    }
}

