using Encog.App.Analyst.Script.Normalize;
using Encog.ML.Data.Basic;
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
        private List<AnalystField> m_outputFields;
        private BasicNetwork m_network;

        /// <summary>
        /// Create a new tester form
        /// </summary>
        /// <param name="network">Trained neural network to test</param>
        /// <param name="inputFields">List of input fields from Encog Analyst</param>
        /// <param name="outputFields">List of output fields from Encog Analyst</param>
        public frmTest(BasicNetwork network, List<AnalystField> inputFields,
            List<AnalystField> outputFields)
        {
            InitializeComponent();

            m_network = network;
            m_inputFields = inputFields;
            m_outputFields = outputFields;

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

            updatePrediction(sender, e);
        }

        private void trkLiens_Scroll(object sender, EventArgs e)
        {
            txtLiens.Text = trkLiens.Value.ToString();

            updatePrediction(sender, e);
        }

        private void trkActions_Scroll(object sender, EventArgs e)
        {
            txtActions.Text = trkActions.Value.ToString();

            updatePrediction(sender, e);
        }

        private void trkAuditEntries_Scroll(object sender, EventArgs e)
        {
            txtAuditEntries.Text = trkAuditEntries.Value.ToString();

            updatePrediction(sender, e);
        }

        private void trkNotesLogged_Scroll(object sender, EventArgs e)
        {
            txtNotesLogged.Text = trkNotesLogged.Value.ToString();

            updatePrediction(sender, e);
        }

        private void txtLoanAmount_TextChanged(object sender, EventArgs e)
        {
            int value;
            Int32.TryParse(txtLoanAmount.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out value);
            trkLoanAmount.Value = value;

            updatePrediction(sender, e);
        }

        private void txtLiens_TextChanged(object sender, EventArgs e)
        {
            int value;
            Int32.TryParse(txtLiens.Text, out value);
            trkLiens.Value = value;

            updatePrediction(sender, e);
        }

        private void txtActions_TextChanged(object sender, EventArgs e)
        {
            int value;
            Int32.TryParse(txtActions.Text, out value);
            trkActions.Value = value;

            updatePrediction(sender, e);
        }

        private void txtAuditEntries_TextChanged(object sender, EventArgs e)
        {
            int value;
            Int32.TryParse(txtAuditEntries.Text, out value);
            trkAuditEntries.Value = value;

            updatePrediction(sender, e);
        }

        private void txtNotesLogged_TextChanged(object sender, EventArgs e)
        {
            int value;
            Int32.TryParse(txtNotesLogged.Text, out value);
            trkNotesLogged.Value = value;

            updatePrediction(sender, e);
        }

        private void updatePrediction(object sender, EventArgs e)
        {
            List<double> inputNodes = new List<double>(); // Input nodes
            double[] dOutput; // Output nodes

            // Must add nodes in the following order:
            // vCoverageType, vTransaction, nLoanAmount, nLiens, nActions, nAuditEntriesPerDay,
            // nTotalNotesPerDay

            // Analyst fields, class numbers and un-normalized numericals
            AnalystField vCoverageType, vTransaction, nLoanAmount, nLiens, nActions,
                nAuditEntriesPerDay, nTotalNotesPerDay, oCancelled, oNumDays;
            int nCoverageTypeClass, nTransactionClass;
            double dLoanAmount, dLiens, dActions, dAuditEntries, dNotes;

            vCoverageType = vTransaction = nLoanAmount = nLiens = nActions =
                nAuditEntriesPerDay = nTotalNotesPerDay = oCancelled = oNumDays = null;
            nCoverageTypeClass = nTransactionClass = 0;
            dLoanAmount = dLiens = dActions = dAuditEntries = dNotes = 0.0;

            // Capture AnalystField objects for each input field
            foreach(AnalystField field in m_inputFields)
            {
                switch(field.Name)
                {
                    case "vCoverageType":
                        vCoverageType = field;
                        break;
                    case "vTransaction":
                        vTransaction = field;
                        break;
                    case "nLoanAmount":
                        nLoanAmount = field;
                        break;
                    case "nLiens":
                        nLiens = field;
                        break;
                    case "nActions":
                        nActions = field;
                        break;
                    case "nAuditEntriesPerDay":
                        nAuditEntriesPerDay = field;
                        break;
                    case "nTotalNotesPerDay":
                        nTotalNotesPerDay = field;
                        break;
                }
            }

            // Capture AnalystField objects for each output field
            foreach (AnalystField field in m_outputFields)
            {
                switch (field.Name)
                {
                    case "oCancelled":
                        oCancelled = field;
                        break;
                    case "oNumDays":
                        oNumDays = field;
                        break;
                }
            }

            // Get class number for vCoverageType
            foreach (ClassItem c in vCoverageType.Classes)
                if (c.Name == cmbCoverageType.Text)
                    nCoverageTypeClass = c.Index;

            // Get class number for vTransaction
            foreach (ClassItem c in vTransaction.Classes)
                if (c.Name == cmbTransactionType.Text)
                    nTransactionClass = c.Index;

            // Get numerical values
            Double.TryParse(txtLoanAmount.Text, out dLoanAmount);
            Double.TryParse(txtLiens.Text, out dLiens);
            Double.TryParse(txtActions.Text, out dActions);
            Double.TryParse(txtAuditEntries.Text, out dAuditEntries);
            Double.TryParse(txtNotesLogged.Text, out dNotes);

            // Endode vCoverageType
            vCoverageType.Init();
            inputNodes.AddRange(vCoverageType.EncodeEquilateral(nCoverageTypeClass).ToList());

            // Encode vTransaction
            vTransaction.Init();
            inputNodes.AddRange(vTransaction.EncodeEquilateral(nTransactionClass).ToList());

            // Normalize and append numerical values
            inputNodes.Add(nLoanAmount.Normalize(dLoanAmount));
            inputNodes.Add(nLiens.Normalize(dLiens));
            inputNodes.Add(nActions.Normalize(dActions));
            inputNodes.Add(nAuditEntriesPerDay.Normalize(dAuditEntries));
            inputNodes.Add(nTotalNotesPerDay.Normalize(dNotes));

            // Make prediction
            dOutput = ((BasicMLData)m_network.Compute(new BasicMLData(inputNodes.ToArray()))).Data;

            // Update Output
            txtCancellation.Text = String.Format("{0:f2}%", oCancelled.DeNormalize(dOutput[0]) * 100.0);
            txtNumDays.Text = String.Format("{0}", oNumDays.DeNormalize(dOutput[1]));
        }
    }
}
