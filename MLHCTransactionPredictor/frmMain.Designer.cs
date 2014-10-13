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
            this.txtHiddenNodes = new System.Windows.Forms.TextBox();
            this.lblHiddenNodes = new System.Windows.Forms.Label();
            this.lblInputNodes = new System.Windows.Forms.Label();
            this.txtInputNodes = new System.Windows.Forms.TextBox();
            this.lblOutputNodes = new System.Windows.Forms.Label();
            this.txtOutputNodes = new System.Windows.Forms.TextBox();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.btnOutputNormalized = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMain
            // 
            this.txtMain.Location = new System.Drawing.Point(12, 128);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMain.Size = new System.Drawing.Size(1032, 315);
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
            this.btnClear.Location = new System.Drawing.Point(12, 99);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(109, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
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
            this.btnPopulate.Location = new System.Drawing.Point(12, 70);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(109, 23);
            this.btnPopulate.TabIndex = 5;
            this.btnPopulate.Text = "Populate Display";
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // btnCreateNeuralNet
            // 
            this.btnCreateNeuralNet.Enabled = false;
            this.btnCreateNeuralNet.Location = new System.Drawing.Point(127, 70);
            this.btnCreateNeuralNet.Name = "btnCreateNeuralNet";
            this.btnCreateNeuralNet.Size = new System.Drawing.Size(109, 23);
            this.btnCreateNeuralNet.TabIndex = 6;
            this.btnCreateNeuralNet.Text = "Create Neural Net";
            this.btnCreateNeuralNet.UseVisualStyleBackColor = true;
            this.btnCreateNeuralNet.Click += new System.EventHandler(this.btnCreateNeuralNet_Click);
            // 
            // txtHiddenNodes
            // 
            this.txtHiddenNodes.Location = new System.Drawing.Point(324, 9);
            this.txtHiddenNodes.Name = "txtHiddenNodes";
            this.txtHiddenNodes.Size = new System.Drawing.Size(25, 20);
            this.txtHiddenNodes.TabIndex = 7;
            this.txtHiddenNodes.Text = "3";
            // 
            // lblHiddenNodes
            // 
            this.lblHiddenNodes.AutoSize = true;
            this.lblHiddenNodes.Location = new System.Drawing.Point(240, 12);
            this.lblHiddenNodes.Name = "lblHiddenNodes";
            this.lblHiddenNodes.Size = new System.Drawing.Size(78, 13);
            this.lblHiddenNodes.TabIndex = 8;
            this.lblHiddenNodes.Text = "Hidden Nodes:";
            // 
            // lblInputNodes
            // 
            this.lblInputNodes.AutoSize = true;
            this.lblInputNodes.Location = new System.Drawing.Point(240, 39);
            this.lblInputNodes.Name = "lblInputNodes";
            this.lblInputNodes.Size = new System.Drawing.Size(68, 13);
            this.lblInputNodes.TabIndex = 9;
            this.lblInputNodes.Text = "Input Nodes:";
            // 
            // txtInputNodes
            // 
            this.txtInputNodes.Location = new System.Drawing.Point(324, 36);
            this.txtInputNodes.Name = "txtInputNodes";
            this.txtInputNodes.ReadOnly = true;
            this.txtInputNodes.Size = new System.Drawing.Size(25, 20);
            this.txtInputNodes.TabIndex = 10;
            // 
            // lblOutputNodes
            // 
            this.lblOutputNodes.AutoSize = true;
            this.lblOutputNodes.Location = new System.Drawing.Point(240, 66);
            this.lblOutputNodes.Name = "lblOutputNodes";
            this.lblOutputNodes.Size = new System.Drawing.Size(76, 13);
            this.lblOutputNodes.TabIndex = 11;
            this.lblOutputNodes.Text = "Output Nodes:";
            // 
            // txtOutputNodes
            // 
            this.txtOutputNodes.Location = new System.Drawing.Point(324, 63);
            this.txtOutputNodes.Name = "txtOutputNodes";
            this.txtOutputNodes.ReadOnly = true;
            this.txtOutputNodes.Size = new System.Drawing.Size(25, 20);
            this.txtOutputNodes.TabIndex = 12;
            // 
            // btnTrain
            // 
            this.btnTrain.Enabled = false;
            this.btnTrain.Location = new System.Drawing.Point(127, 99);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(109, 23);
            this.btnTrain.TabIndex = 13;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Enabled = false;
            this.btnAnalyze.Location = new System.Drawing.Point(128, 11);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(108, 23);
            this.btnAnalyze.TabIndex = 14;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // btnOutputNormalized
            // 
            this.btnOutputNormalized.Enabled = false;
            this.btnOutputNormalized.Location = new System.Drawing.Point(127, 41);
            this.btnOutputNormalized.Name = "btnOutputNormalized";
            this.btnOutputNormalized.Size = new System.Drawing.Size(109, 23);
            this.btnOutputNormalized.TabIndex = 15;
            this.btnOutputNormalized.Text = "Output Normalized";
            this.btnOutputNormalized.UseVisualStyleBackColor = true;
            this.btnOutputNormalized.Click += new System.EventHandler(this.btnOutputNormalized_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 455);
            this.Controls.Add(this.btnOutputNormalized);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.txtOutputNodes);
            this.Controls.Add(this.lblOutputNodes);
            this.Controls.Add(this.txtInputNodes);
            this.Controls.Add(this.lblInputNodes);
            this.Controls.Add(this.lblHiddenNodes);
            this.Controls.Add(this.txtHiddenNodes);
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
        private System.Windows.Forms.TextBox txtHiddenNodes;
        private System.Windows.Forms.Label lblHiddenNodes;
        private System.Windows.Forms.Label lblInputNodes;
        private System.Windows.Forms.TextBox txtInputNodes;
        private System.Windows.Forms.Label lblOutputNodes;
        private System.Windows.Forms.TextBox txtOutputNodes;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnOutputNormalized;
    }
}

