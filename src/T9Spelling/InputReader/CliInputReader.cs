namespace T9Spelling.InputReader
{
    using System;
    using System.Collections.Generic;
    using Converter.Models.Data;

    /// <summary>
    /// Class for reading data from command line
    /// </summary>
    internal sealed class CliReader : IReader
    {
        private readonly string[] args;

        internal CliReader(string[] arguments = null)
        {
            args = arguments ?? Environment.GetCommandLineArgs();
        }

        /// <summary>
        /// Reads data from command line arguments
        /// </summary>
        /// <returns>Returns data in convenient format</returns>
        public InputData ReadData()
        {
            var number = ReadNumberFromArgs();
            var cases = ReadCasesFromArgs(number);
            var input = new InputData(number, cases);
            return input;
        }

        /// <summary>
        /// Reads number of cases from command line arguments
        /// </summary>
        /// <returns>Number of cases</returns>
        private int ReadNumberFromArgs()
        {
            var index = CliParser.GetTagIndex("n");

            if (!int.TryParse(args[index + 1], out var number))
            {
                throw new Exception("Failed to parse number of messages.");
            }

            return number;
        }

        /// <summary>
        /// Reads cases from command line arguments
        /// </summary>
        /// <param name="number">Number of arguments</param>
        /// <returns>Cases</returns>
        private Dictionary<int, string> ReadCasesFromArgs(int number)
        {
            var cases = new Dictionary<int, string>();
            var tagIndex = CliParser.GetTagIndex("m");
            var messageStartIndex = tagIndex + 1;
            for (var i = messageStartIndex; i < messageStartIndex + number; i++)
            {
                if (args[i][0] == '-')
                {
                    throw new Exception($"Failed to take {i - messageStartIndex} message.");
                }

                cases.Add(i - messageStartIndex + 1, args[i]);
            }

            return cases;
        }
    }
}