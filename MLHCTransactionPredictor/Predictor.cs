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
    class Predictor : IDisposable
    {
        public Predictor(TextBox txtOutput)
        {
            m_txtOutputWindow = txtOutput;
        }

        /// <summary>
        /// Opens connection to database, must be called before LoadData()
        /// </summary>
        /// <returns>true if successful, false otherwise</returns>
        public bool OpenConnection()
        {
            return true;
        }

        /// <summary>
        /// Loads data from the database, must be called after OpenConnection()
        /// </summary>
        /// <returns>Number of records loaded, -1 on error</returns>
        public int LoadData()
        {
            return 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Test()
        {
            BasicNetwork network = new BasicNetwork();
            network.AddLayer(new BasicLayer(2));
            network.AddLayer(new BasicLayer(2));
            network.AddLayer(new BasicLayer(1));
            network.Structure.FinalizeStructure();
            network.Reset();

            double[][] XOR_INPUT = {
                                       new double[2] {0.0, 0.0},
                                       new double[2] {1.0, 0.0},
                                       new double[2] {0.0, 1.0},
                                       new double[2] {1.0, 1.0}
                                   };

            double[][] XOR_IDEAL = {
                                       new double[1] {0.0},
                                       new double[1] {1.0},
                                       new double[1] {1.0},
                                       new double[1] {0.0}
                                   };

            INeuralDataSet trainingSet = new BasicNeuralDataSet(XOR_INPUT, XOR_IDEAL);

            ITrain train = new ResilientPropagation(network, trainingSet);

            int epoch = 1;

            do
            {
                train.Iteration();
                m_txtOutputWindow.AppendText(String.Format("Epoch #{0}, Error:{1}{2}", epoch, train.Error, Environment.NewLine));
                epoch++;
            } while ((epoch < 5000) && (train.Error > 0.01));
        }

        private TextBox m_txtOutputWindow;
    }
}
