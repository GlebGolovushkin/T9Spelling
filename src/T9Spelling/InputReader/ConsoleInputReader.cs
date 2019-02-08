namespace T9Spelling.InputReader
{
    using System;
    using System.Collections.Generic;
    using Converter.Models.Data;
    using T9Spelling.UI;

    /// <summary>
    /// Class for reading data from console
    /// </summary>
    internal sealed class ConsoleReader : IReader
    {
        /// <summary>
        /// Reads data from console
        /// </summary>
        /// <returns>Data in convenient format</returns>
        public InputData ReadData()
        {
            var number = ReadNumberFromConsole();
            var cases = ReadCasesFromConsole(number);
            if (cases.Count != number)
            {
                throw new Exception("Wrong number of messages.");
            }

            var input = new InputData(number, cases);
            return input;
        }

        /// <summary>
        /// Reads number from console
        /// </summary>
        /// <returns>number</returns>
        private int ReadNumberFromConsole()
        {
            if (!int.TryParse(Console.ReadLine(), out var number))
            {
                throw new Exception("Failed to parse messages number from console.");
            }

            return number;
        }

        /// <summary>
        /// Reads cases from console
        /// </summary>
        /// <param name="number">Number of cases</param>
        /// <returns>Cases</returns>
        private Dictionary<int, string> ReadCasesFromConsole(int number)
        {
            var cases = new Dictionary<int, string>();
            for (var i = 1; i <= number;)
            {
                var message = Console.ReadLine();
                if (!string.IsNullOrEmpty(message))
                {
                    cases.Add(i, message);
                    i++;
                }
                else
                {
                    ConsoleUI.PrintWarning($"Please write {i} message.");
                }
            }

            return cases;
        }
    }
}