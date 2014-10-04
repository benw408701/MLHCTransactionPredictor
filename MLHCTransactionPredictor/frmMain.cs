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

        private void btnTest_Click(object sender, EventArgs e)
        {
            m_predictor = new Predictor(txtMain);

            m_predictor.Test();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
#if DEBUG
            txtMain.AppendText(String.Format("Open File Result: {0}{1}",open.ShowDialog().ToString(),
                Environment.NewLine));
            txtMain.AppendText(String.Format("File Name: {0}{1}", open.FileName, Environment.NewLine));
#endif
            m_data = new CSVData(open.FileName);
        }
    }
}
