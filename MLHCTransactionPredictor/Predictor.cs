using Encog.Engine.Network.Activation;
using Encog.ML.Data.Basic;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training.Propagation.Back;
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
        public bool ReadyToTrain
        {
            get { return !(m_train == null); }
        }

        public Predictor(TextBox txtOutput, CSVData data, int hiddenNodes)
        {
            m_txtOutputWindow = txtOutput;
            m_data = data;

            // Populate the input and output arrays
            LoadData();

            // Create Neural Network
            m_network = new BasicNetwork();
            m_network.AddLayer(new BasicLayer(null, true, m_data.InputNodes));
            m_network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, hiddenNodes));
            m_network.AddLayer(new BasicLayer(new ActivationSigmoid(), false, m_data.OutputNodes));
            m_network.Structure.FinalizeStructure();
            m_network.Reset();

            m_train = new Backpropagation(m_network, new BasicMLDataSet(m_input, m_output));
        }

        public void Train(double error, int maxIterations = 1000)
        {
            do
            {
                m_train.Iteration();
                m_txtOutputWindow.AppendText(String.Format("Iteration Number: {0}, Error Rate: {1}{2}",
                    m_train.IterationNumber, m_train.Error, Environment.NewLine));
            } while (m_train.Error > error && m_train.IterationNumber < maxIterations);
        }

        private void LoadData()
        {
            int outCol, inCol; // column numbers for the input node and output node arrays
            m_input = new double[m_data.Rows - 1][];
            m_output = new double[m_data.Rows - 1][];

            for (int i = 0; i < m_data.Rows - 1; i++)
            {
                // Initialize node rows
                outCol = inCol = 0; 
                m_input[i] = new double[m_data.InputNodes];
                m_output[i] = new double[m_data.OutputNodes];
                for (int j = 0; j < m_data.Columns; j++)
                {
                    // Ouput Row
                    if (m_data[0,j][0] == 'o')
                    {
                        m_output[i][outCol] = Double.Parse(m_data[i + 1, j]);
                        outCol++;
                    }
                    // Input Row
                    else if(m_data[0,j][0] != 's')
                    {
                        m_input[i][inCol] = Double.Parse(m_data[i + 1, j]);
                        inCol++;
                    }
                }
            }
        }

        private TextBox m_txtOutputWindow;
        private CSVData m_data;
        private BasicNetwork m_network;
        private Backpropagation m_train;
        private double[][] m_input;
        private double[][] m_output;
    }
}
