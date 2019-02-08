namespace T9Spelling.UI
{
    using Converter.Models.Data;

    /// <summary>
    /// Interface for user interface work
    /// </summary>
    internal static class UIHelper
    {
        /// <summary>
        /// Prints result
        /// </summary>
        /// <param name="output">Output data</param>
        /// <param name="inputData">Input data</param>
        /// <param name="fileOutputPath">File output path</param>
        internal static void PrintResult(OutputData output, InputData inputData, string fileOutputPath = null)
        {
            if (!string.IsNullOrEmpty(fileOutputPath))
            {
                FileUI.PrintResult(output, inputData, fileOutputPath);
            }
            else
            {
                ConsoleUI.PrintResult(output, inputData);
            }
        }
    }
}