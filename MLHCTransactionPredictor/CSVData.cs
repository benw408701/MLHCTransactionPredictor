using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLHCTransactionPredictor
{
    class CSVData
    {
        /// <summary>
        /// Data from the csv file as a list of a list of strings
        /// </summary>
        private List<List<string>> m_data = new List<List<string>>();;

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
        }

        /// <summary>
        /// Processes CSV file data and normalizes into a matrix floating point numbers
        /// that can be read by the neural network. Column headers in the CSV file
        /// must be flagged with the first letter of the column header as follows:
        ///     s = "skip": do not include in the output
        ///     v = "value": represents an identifier that has a numerical value (integer), but
        ///         should not be treated as a number and needs to be encoded
        ///     t = "text": represents text that needs to be encoded
        ///     n = "number" represents a number that does not need encoding
        ///     o = "output" represents an output value
        /// The encoding process for values will be to represent the number in binary and treat
        /// each bit as a node. The encoding process for text will be to convert each character to
        /// upper case, convert to the ascii code, subtract 65 (since 'A' is 65) then follow the
        /// same encoding used for values.
        /// </summary>
        private void ProcessData()
        {

        }
    }
}
