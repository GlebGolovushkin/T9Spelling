namespace T9Spelling.InputReader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Converter.Models.Data;

    /// <summary>
    /// Class for reading data from file
    /// </summary>
    internal sealed class ReaderInput : IReader
    {
        private readonly string filePath;

        internal ReaderInput(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Read data from file
        /// </summary>
        /// <returns>data in convenient format</returns>
        public InputData ReadData()
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Failed to find file in '{filePath}' path.");
            }

            var inputLines = File.ReadAllLines(filePath, Encoding.UTF8);
            var number = ReadNumberFromString(inputLines[0]);
            var cases = ReadCasesFromLines(inputLines, number);
            var input = new InputData(number, cases);
            return input;
        }

        /// <summary>
        /// Reads number of cases from file
        /// </summary>
        /// <param name="stringWithNumber">string with number</param>
        /// <returns>number</returns>
        private int ReadNumberFromString(string stringWithNumber)
        {
            var parse = int.TryParse(stringWithNumber, out var number);
            if (parse)
            {
                return number;
            }

            throw new ArgumentException("Failed to parse messages number from file.");
        }

        /// <summary>
        /// Reads cases from file
        /// </summary>
        /// <param name="inputLines">input lines</param>
        /// <param name="number">number of cases</param>
        /// <returns>cases</returns>
        private Dictionary<int, string> ReadCasesFromLines(string[] inputLines, int number)
        {
            var cases = new Dictionary<int, string>();

            for (var i = 1; i < inputLines.Length; i++)
            {
                if (!string.IsNullOrEmpty(inputLines[i]))
                {
                    cases.Add(i, inputLines[i]);
                }
            }

            if (cases.Count != number)
            {
                throw new ArgumentException($"Failed to get {number} messages.");
            }

            return cases;
        }
    }
}