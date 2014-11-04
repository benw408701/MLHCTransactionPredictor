using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLHCTransactionPredictor
{
    public partial class frmMain : Form
    {
        private Predictor m_predictor;
        private CSVData m_data;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            txtMain.AppendText(String.Format("Open File Result: {0}{1}",open.ShowDialog().ToString(),
                Environment.NewLine));
            txtMain.AppendText(String.Format("File Name: {0}{1}", open.FileName, Environment.NewLine));
            m_data = new CSVData(open.FileName);

            txtInputNodes.Text = m_data.InputNodes.ToString();
            txtOutputNodes.Text = m_data.OutputNodes.ToString();
            txtTotalRecords.Text = (m_data.Rows - 1).ToString();
            UpdateTrainingSetSize();

            btnOpen.Enabled = false;
            btnCreateNeuralNet.Enabled = true;
            btnAnalyze.Enabled = true;
            btnLoadNetwork.Enabled = true;
        }

        private void UpdateTrainingSetSize()
        {
            double percent = Double.Parse(txtPercentValidation.Text) * .01;

            txtValidationSetSize.Text = Math.Round((m_data.Rows - 1) * percent).ToString();
            txtTrainingSetSize.Text = Math.Round((m_data.Rows - 1) * (1 - percent)).ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMain.Clear();
            btnAnalyze.Enabled = btnCreateNeuralNet.Enabled = btnOutputNormalized.Enabled = btnTrain.Enabled = 
                btnSaveNetwork.Enabled = btnLoadNetwork.Enabled = btnTestNetwork.Enabled = false;
            btnOpen.Enabled = true;
            m_data = null;
            m_predictor = null;
        }

        /// <summary>
        /// Output first 10 rows of data in the display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPopulate_Click(object sender, EventArgs e)
        {
            if (m_data != null)
            {
                for (int i = 1; i <= (m_data.Rows <= 10 ? m_data.Rows : 10); i++)
                {
                    txtMain.AppendText(String.Format("{1}Record #{0}{1}============={1}", i, Environment.NewLine));
                    for (int j = 0; j < m_data.Columns; j++)
                        txtMain.AppendText(String.Format("{0}: {1}{2}", m_data[0, j], m_data[i, j], Environment.NewLine));
                }
            }
            else
                MessageBox.Show("Data has not been loaded yet, please open a .csv file to load the data.", "No Data to Display",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCreateNeuralNet_Click(object sender, EventArgs e)
        {
            m_predictor = new Predictor(txtMain, m_data, Int32.Parse(txtHiddenNodes.Text),
                Double.Parse(txtPercentValidation.Text) * .01);

            btnTrain.Enabled = true;
            btnSaveNetwork.Enabled = true;
            btnTestNetwork.Enabled = true;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            m_predictor.Train(Double.Parse(txtAllowableError.Text) * .01,
                Int32.Parse(txtMaxTrainingCycles.Text));
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            m_data.Analyze(txtMain);

            btnOutputNormalized.Enabled = true;
        }

        private void btnOutputNormalized_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog();

            save.DefaultExt = ".csv";

            save.ShowDialog();

            m_data.Normalize(save.FileName);
        }

        private void txtPercentValidation_TextChanged(object sender, EventArgs e)
        {
            UpdateTrainingSetSize();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            m_predictor.Validate();
        }

        private void btnSaveNetwork_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog();

            save.DefaultExt = ".eg";

            save.ShowDialog();

            m_predictor.SaveNetwork(save.FileName);
        }

        private void btnLoadNetwork_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();

            open.ShowDialog();

            if (open.FileName != "")
                m_predictor = new Predictor(open.FileName, txtMain, m_data, Double.Parse(txtPercentValidation.Text) * .01);

            txtHiddenNodes.Text = m_predictor.HiddenNodes.ToString();

            btnTrain.Enabled = true;
            btnTestNetwork.Enabled = true;
        }

        private void btnTestNetwork_Click(object sender, EventArgs e)
        {
            frmTest testForm = new frmTest(m_predictor.Network, m_data.AnalystInputFields);
            testForm.ShowDialog();
        }
    }
}
