namespace T9Spelling.UI
{
    using System;
    using System.Linq;
    using Converter.Models.Data;

    /// <summary>
    /// Class with user interface using console
    /// </summary>
    public static class ConsoleUI
    {
        private const string INPUT_HEADER = "Input";
        private const string OUTPUT_HEADER = "Output";
        private const ConsoleColor DEFAULT_TEXT_COLOR = ConsoleColor.White;
        private const ConsoleColor EXCEPTION_TEXT_COLOR = ConsoleColor.Red;
        private const ConsoleColor WARNING_TEXT_COLOR = ConsoleColor.Yellow;

        /// <summary>
        /// Prints result
        /// </summary>
        /// <param name="outputData">Output data</param>
        /// <param name="inputData">Input data</param>
        internal static void PrintResult(OutputData outputData, InputData inputData)
        {
            if (inputData.Cases.Count != outputData.Cases.Count)
            {
                throw new ArgumentException("Invalid number of cases in input or output data.");
            }

            var maxWidth = inputData.Cases.Values.Max(s => s.Length);
            maxWidth = Math.Max(maxWidth, INPUT_HEADER.Length);
            maxWidth = maxWidth > 50 ? 1 : maxWidth;
            var formatString = $"{{0, -{maxWidth}}} | ";
            ClearScreen();
            PrintHeaders(formatString);
            Console.WriteLine(formatString, inputData.Number);
            for (var i = 1; i <= inputData.Number; i++)
            {
                Console.Write(formatString, inputData.Cases[i]);
                Console.WriteLine(outputData.Cases[i]);
            }
        }

        /// <summary>
        /// Clears console
        /// </summary>
        private static void ClearScreen()
        {
            Console.Clear();
        }

        /// <summary>
        /// Prints headers
        /// </summary>
        /// <param name="formatString"></param>
        private static void PrintHeaders(string formatString)
        {
            Console.Write(formatString, INPUT_HEADER);
            Console.WriteLine(OUTPUT_HEADER);
        }

        /// <summary>
        /// Prints Exception
        /// </summary>
        /// <param name="message">Exception message</param>
        internal static void PrintException(string message)
        {
            PrintMessage(message, EXCEPTION_TEXT_COLOR);
        }

        /// <summary>
        /// Prints warnings
        /// </summary>
        /// <param name="message"> Waning message</param>
        internal static void PrintWarning(string message)
        {
            PrintMessage(message, WARNING_TEXT_COLOR);
        }

        /// <summary>
        /// Print message
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="color">Message color</param>
        internal static void PrintMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = DEFAULT_TEXT_COLOR;
        }
    }
}