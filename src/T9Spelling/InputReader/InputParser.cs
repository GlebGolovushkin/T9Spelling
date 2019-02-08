namespace T9Spelling.InputReader
{
    using System;
    using System.IO;
    using Converter.Models.Data;
    using Converter.Models.Keypad;

    /// <summary>
    /// Class for parsing input data
    /// </summary>
    internal static class InputParser
    {
        private static readonly string[] args;

        static InputParser()
        {
            args = Environment.GetCommandLineArgs();
        }

        /// <summary>
        /// Gets input data
        /// </summary>
        /// <returns>Input data</returns>
        internal static InputData GetInputData()
        {
            IReader inputReader;
            if (args.Length > 1)
            {
                var fileInputIndex = CliParser.GetTagIndex("f");
                if (fileInputIndex != -1)
                {
                    inputReader = new ReaderInput(args[fileInputIndex + 1]);
                }
                else
                {
                    inputReader = new CliReader();
                }
            }
            else
            {
                inputReader = new ConsoleReader();
            }

            var inputData = inputReader.ReadData();
            return inputData;
        }

        /// <summary>
        /// Gets keypad type
        /// </summary>
        /// <returns>Keypad type</returns>
        internal static KeypadLayout GetKeyboardType()
        {
            if (CliParser.GetTagIndex("ru") != -1)
            {
                return KeypadLayout.Russian;
            }

            return KeypadLayout.English;
        }

        /// <summary>
        /// Gets output file path
        /// </summary>
        /// <returns>output file path</returns>
        internal static string GetOutputFilePath()
        {
            var fileOutputIndex = CliParser.GetTagIndex("of");
            if (fileOutputIndex != -1)
            {
                var fileOutputPath = args[fileOutputIndex + 1];
                var directoryInfo = new FileInfo(fileOutputPath).Directory;
                if (directoryInfo != null)
                {
                    var directory = directoryInfo.FullName;
                    if (Directory.Exists(directory))
                    {
                        return fileOutputPath;
                    }

                    throw new DirectoryNotFoundException($"Failed to find directory in {directory}");
                }
            }

            return null;
        }
    }
}