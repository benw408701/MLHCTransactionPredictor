using Encog.App.Analyst.Script.Normalize;
using Encog.Neural.Networks;
using Encog.Util.Arrayutil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLHCTransactionPredictor
{
    public partial class frmTest : Form
    {
        private List<AnalystField> m_inputFields;
        private BasicNetwork m_network;

        /// <summary>
        /// Create a new tester form
        /// </summary>
        /// <param name="network">Trained neural network to test</param>
        /// <param name="inputFields">List of input fields from Encog Analyst</param>
        public frmTest(BasicNetwork network, List<AnalystField> inputFields)
        {
            InitializeComponent();

            m_network = network;
            m_inputFields = inputFields;

            foreach(AnalystField field in inputFields)
            {
                switch(field.Name)
                {
                    case "vCoverageType":
                        foreach (ClassItem item in field.Classes)
                            cmbCoverageType.Items.Add(item.Name);
                        cmbCoverageType.SelectedIndex = 0;
                        break;
                    case "vTransaction":
                        foreach (ClassItem item in field.Classes)
                            cmbTransactionType.Items.Add(item.Name);
                        cmbTransactionType.SelectedIndex = 0;
                        break;
                    case "nLoanAmount":
                        trkLoanAmount.Minimum = (int)field.ActualLow;
                        trkLoanAmount.Maximum = (int)field.ActualHigh;
                        trkLoanAmount.TickFrequency = (int)(field.ActualHigh / 10.0);
                        txtLoanAmount.Text = String.Format("{0:C2}", trkLoanAmount.Value);
                        break;
                    case "nLiens":
                        trkLiens.Minimum = (int)field.ActualLow;
                        trkLiens.Maximum = (int)field.ActualHigh;
                        trkLiens.TickFrequency = (int)(field.ActualHigh / 10.0);
                        txtLiens.Text = trkLiens.Value.ToString();
                        break;
                    case "nActions":
                        trkActions.Minimum = (int)field.ActualLow;
                        trkActions.Maximum = (int)field.ActualHigh;
                        trkActions.TickFrequency = (int)(field.ActualHigh / 10.0);
                        txtActions.Text = trkActions.Value.ToString();
                        break;
                    case "nAuditEntriesPerDay":
                        trkAuditEntries.Minimum = (int)field.ActualLow;
                        trkAuditEntries.Maximum = (int)field.ActualHigh;
                        trkAuditEntries.TickFrequency = (int)(field.ActualHigh / 10.0);
                        txtAuditEntries.Text = trkAuditEntries.Value.ToString();
                        break;
                    case "nTotalNotesPerDay":
                        trkNotesLogged.Minimum = (int)field.ActualLow;
                        trkNotesLogged.Maximum = (int)field.ActualHigh;
                        trkNotesLogged.TickFrequency = (int)(field.ActualHigh / 10.0);
                        txtNotesLogged.Text = trkNotesLogged.Value.ToString();
                        break;
                }
            }
        }

        private void trkLoanAmount_Scroll(object sender, EventArgs e)
        {
            txtLoanAmount.Text = String.Format("{0:C2}", trkLoanAmount.Value);
        }

        private void trkLiens_Scroll(object sender, EventArgs e)
        {
            txtLiens.Text = trkLiens.Value.ToString();
        }

        private void trkActions_Scroll(object sender, EventArgs e)
        {
            txtActions.Text = trkActions.Value.ToString();
        }

        private void trkAuditEntries_Scroll(object sender, EventArgs e)
        {
            txtAuditEntries.Text = trkAuditEntries.Value.ToString();
        }

        private void trkNotesLogged_Scroll(object sender, EventArgs e)
        {
            txtNotesLogged.Text = trkNotesLogged.Value.ToString();
        }

        private void txtLoanAmount_TextChanged(object sender, EventArgs e)
        {
            int value;
            Int32.TryParse(txtLoanAmount.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out value);
            trkLoanAmount.Value = value;
        }

        private void txtLiens_TextChanged(object sender, EventArgs e)
        {
            int value;
            Int32.TryParse(txtLiens.Text, out value);
            trkLiens.Value = value;
        }

        private void txtActions_TextChanged(object sender, EventArgs e)
        {
            int value;
            Int32.TryParse(txtActions.Text, out value);
            trkActions.Value = value;
        }

        private void txtAuditEntries_TextChanged(object sender, EventArgs e)
        {
            int value;
            Int32.TryParse(txtAuditEntries.Text, out value);
            trkAuditEntries.Value = value;
        }

        private void txtNotesLogged_TextChanged(object sender, EventArgs e)
        {
            int value;
            Int32.TryParse(txtNotesLogged.Text, out value);
            trkNotesLogged.Value = value;
        }
    }
}
