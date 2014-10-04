using Encog.Neural.Data.Basic;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Neural.NeuralData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLHCTransactionPredictor
{
    /// <summary>
    /// Manages loading training data, creating artificial neural network, validating against validation set
    /// loading saved trained ANN and saving ANN's
    /// </summary>
    class Predictor
    {
        public Predictor(TextBox txtOutput, CSVData data)
        {
            m_txtOutputWindow = txtOutput;
            m_data = data;
        }

        private TextBox m_txtOutputWindow;
        private CSVData m_data;
    }
}
