using Encog.App.Analyst;
using Encog.App.Analyst.CSV.Normalize;
using Encog.App.Analyst.Script.Normalize;
using Encog.App.Analyst.Wizard;
using Encog.Util.Arrayutil;
using Encog.Util.CSV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLHCTransactionPredictor
{
    class CSVData
    {
        /// <summary>
        /// Data from the csv file as a list of a list of strings
        /// </summary>
        private List<List<string>> m_data = new List<List<string>>();

        private int m_inputNodes;
        private int m_outputNodes;
        private EncogAnalyst m_analyst;
        private string m_fileName;

        /// <summary>
        /// Total number of rows
        /// </summary>
        public int Rows
        {
            get { return m_data.Count; }
        }

        /// <summary>
        /// Total number of columns
        /// </summary>
        public int Columns
        {
            get { return m_data[0].Count; }
        }

        /// <summary>
        /// Total number of output nodes
        /// </summary>
        public int OutputNodes
        {
            get { return m_outputNodes; }
        }

        /// <summary>
        /// Total number of input nodes
        /// </summary>
        public int InputNodes
        {
            get { return m_inputNodes; }
        }

        /// <summary>
        /// Indexer for CSV data
        /// </summary>
        /// <param name="row">Row to access</param>
        /// <param name="col">Column to access</param>
        /// <returns>Value at that row/column pair</returns>
        public string this[int row, int col]
        {
            get { return m_data[row][col]; }
        }

        /// <summary>
        /// Constructs a new CSVData object, needs a CSV file to open
        /// </summary>
        /// <param name="fileName">Full path to the CSV file</param>
        public CSVData(string fileName)
        {
            // Open file in read mode and create new stream reader object
            var reader = new StreamReader(File.OpenRead(fileName));

            // Read each row into memory
            while (!reader.EndOfStream)
                m_data.Add(reader.ReadLine().Split(',').ToList());
            reader.Close();

            // Count the number of input and output nodes
            CountNodes();

            m_fileName = fileName;
        }

        public void Analyze(TextBox txtOut)
        {
            // Use analyst
            m_analyst = new EncogAnalyst();
            var source = new FileInfo(m_fileName);
            var wizard = new AnalystWizard(m_analyst);

            wizard.Wizard(source, true, AnalystFileFormat.DecpntComma);

            // Set the minimum value for normalization
            foreach (AnalystField field in m_analyst.Script.Normalize.NormalizedFields)
                field.NormalizedLow = 0.0;

            txtOut.AppendText("Fields found in file:" + Environment.NewLine);
            foreach (AnalystField field in m_analyst.Script.Normalize.NormalizedFields)
                txtOut.AppendText(String.Format("{0}, action = {1}, min = {2}, max = {3}{4}",
                    field.Name, field.Action, field.ActualLow, field.ActualHigh, Environment.NewLine));
        }

        public void Normalize(string outputFileName)
        {
            var norm = new AnalystNormalizeCSV();
            var source = new FileInfo(m_fileName);
            var target = new FileInfo(outputFileName);

            norm.Analyze(source, true, CSVFormat.DecimalPoint, m_analyst);

            norm.ProduceOutputHeaders = true;
            norm.Normalize(target);
        }


        /// <summary>
        /// Compute the number of input and output nodes
        /// </summary>
        private void CountNodes()
        {
            m_outputNodes = m_inputNodes = 0;

            for (int i = 0; i < m_data[0].Count; i++)
                if (m_data[0][i][0] == 'o')
                    m_outputNodes++;
                else if (m_data[0][i][0] != 's')
                    m_inputNodes++;
        }

        /*
        /// <summary>
        /// Processes CSV file data and normalizes into a matrix floating point numbers
        /// that can be read by the neural network. Column headers in the CSV file
        /// must be flagged with the first letter of the column header as follows:
        ///     s = "skip": do not include in the output
        ///     v = "value": represents an identifier that has a text or numerical value
        ///         that should not be treated as a number and needs to be encoded
        ///     n = "number" represents a number that does not need encoding
        ///     o = "output" represents an output value
        /// The encoding process for values will be to represent the number in binary and treat
        /// each bit as a node. The encoding process for text will be to convert each character to
        /// upper case, convert to the ascii code, subtract 65 (since 'A' is 65) then follow the
        /// same encoding used for values.
        /// </summary>
        public void ProcessData()
        {
            // Check each header and if it is a value field, split it out
            int column = 0;
            while (column < m_data[0].Count)
                if (m_data[0][column][0] == 'v')
                {
                    int maxIdent = Flatten(column) - 1; // renumber identifiers and int's starting at 0
                    column += Split(column, maxIdent);
                }
                else
                    column++;

            // Compute the number of input and output nodes
            CountNodes();

        }
        */

        /*
        /// <summary>
        /// Splits a column into binary bits to represent each possible identifier. Identifiers
        /// are integers that start counting at 0. Maximum identifier size is 16 bits.
        /// </summary>
        /// <param name="column">The column to split</param>
        /// <param name="maxIdent">The maximum value in the identifier column. If the max
        /// value is 7 for instance then the column will be split into 3 since lg 8 = 3</param>
        /// <returns>The number of new columns that have been inserted</returns>
        private int Split(int column, int maxIdent)
        {
            // Compute the new number of columns
            int numNewCols = (int)Math.Ceiling(Math.Log((double)maxIdent + 1.0, 2.0));

            if (numNewCols > 16)
                ;// Throw exception
            // Only proceed if we need to split
            else if (numNewCols > 1)
            {
                // Insert and rename the column headers (put .n at the end of each where n is 1 to numNewCols
                string colHeader = m_data[0][column];
                m_data[0][column] = String.Format("{0}.{1}", colHeader, numNewCols);
                for (int i = numNewCols - 1; i >= 1; i--)
                    m_data[0].Insert(column, String.Format("{0}.{1}", colHeader, i));

                // Split each remaining row into binary representation
                for (int i = 1; i < m_data.Count; i++)
                {
                    // Extract the identifier and set the value in the right-most column
                    ushort identifier = ushort.Parse(m_data[i][column]);
                    m_data[i][column] = (0x0001 & identifier).ToString();

                    // Continue to insert new columns and set the bit value
                    for (int j = numNewCols - 1; j >= 1; j--)
                    {
                        // Shift identifier once to the right
                        identifier >>= 1;
                        m_data[i].Insert(column, (0x0001 & identifier).ToString());
                    }
                }
            }

            return numNewCols;
        }
        */

        /*
        /// <summary>
        /// Take a value column and for each item renumber starting at 0
        /// </summary>
        /// <param name="colNum">The column number in the data table to flatten</param>
        /// <returns>The total number of unique values</returns>
        private int Flatten(int colNum)
        {
            // List to store each unique value in the column
            var uniqueIdentifiers = new List<string>();

            for (int i = 1; i < m_data.Count; i++)
            {
                if (uniqueIdentifiers.Contains(m_data[i][colNum]))
                    // Set to new value (0-based index of the unique array)
                    m_data[i][colNum] = uniqueIdentifiers.IndexOf(m_data[i][colNum]).ToString();
                else
                {
                    // Add the value to the unique array and set the new value in the data array
                    uniqueIdentifiers.Add(m_data[i][colNum]);
                    m_data[i][colNum] = (uniqueIdentifiers.Count - 1).ToString();
                }
            }

            return uniqueIdentifiers.Count;
        }
        */
    }
}
