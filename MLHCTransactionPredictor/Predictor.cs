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

        public Predictor(TextBox txtOutput, CSVData data, int hiddenNodes, double percentValidation)
        {
            m_txtOutputWindow = txtOutput;
            m_data = data;

            // Populate the input and output arrays
            LoadData(percentValidation);

            // Create Neural Network
            m_network = new BasicNetwork();
            m_network.AddLayer(new BasicLayer(null, true, m_data.InputNodes));
            m_network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, hiddenNodes));
            m_network.AddLayer(new BasicLayer(new ActivationSigmoid(), false, m_data.OutputNodes));
            m_network.Structure.FinalizeStructure();
            m_network.Reset();

            m_train = new Backpropagation(m_network, new BasicMLDataSet(m_inputTraining, m_outputTraining));
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

        private void LoadData(double percentValidation)
        {
            int outCol, inCol; // column numbers for the input node and output node arrays
            int validationSetSize, trainingSetSize;

            validationSetSize = (int)Math.Round((m_data.Rows - 1) * percentValidation);
            trainingSetSize = (int)Math.Round((m_data.Rows - 1) * (1 - percentValidation));

            m_inputTraining = new double[trainingSetSize][];
            m_outputTraining = new double[trainingSetSize][];
            m_inputValidation = new double[validationSetSize][];
            m_outputValidation = new double[validationSetSize][];

            for (int i = 0; i < trainingSetSize; i++)
            {
                // Initialize node rows
                outCol = inCol = 0;
                m_inputTraining[i] = new double[m_data.InputNodes];
                m_outputTraining[i] = new double[m_data.OutputNodes];
                for (int j = 0; j < m_data.Columns; j++)
                {
                    // Ouput Row
                    if (m_data[0, j][0] == 'o')
                    {
                        m_outputTraining[i][outCol] = Double.Parse(m_data[i + 1, j]);
                        outCol++;
                    }
                    // Input Row
                    else if (m_data[0, j][0] != 's')
                    {
                        m_inputTraining[i][inCol] = Double.Parse(m_data[i + 1, j]);
                        inCol++;
                    }
                }
            }
            for (int i = 0; i < validationSetSize; i++)
            {
                // Initialize node rows
                outCol = inCol = 0;
                m_inputValidation[i] = new double[m_data.InputNodes];
                m_outputValidation[i] = new double[m_data.OutputNodes];
                for (int j = 0; j < m_data.Columns; j++)
                {
                    // Ouput Row
                    if (m_data[0, j][0] == 'o')
                    {
                        m_outputValidation[i][outCol] = Double.Parse(m_data[i + 1, j]);
                        outCol++;
                    }
                    // Input Row
                    else if (m_data[0, j][0] != 's')
                    {
                        m_inputValidation[i][inCol] = Double.Parse(m_data[i + 1, j]);
                        inCol++;
                    }
                }
            }
        }

        private TextBox m_txtOutputWindow;
        private CSVData m_data;
        private BasicNetwork m_network;
        private Backpropagation m_train;
        private double[][] m_inputTraining;
        private double[][] m_outputTraining;

        private double[][] m_inputValidation;
        private double[][] m_outputValidation;
    }
}
