namespace T9Spelling.UI
{
    using System.IO;
    using Converter.Models.Data;

    /// <summary>
    /// Class with user interface using file
    /// </summary>
    internal static class FileUI
    {
        /// <summary>
        /// Prints result in file
        /// </summary>
        /// <param name="outputData">Output data</param>
        /// <param name="inputData">Input data</param>
        /// <param name="path">Path</param>
        internal static void PrintResult(OutputData outputData, InputData inputData, string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            using (TextWriter tw = new StreamWriter(path))
            {
                for (var i = 1; i <= inputData.Number; i++)
                {
                    tw.WriteLine(outputData.Cases[i]);
                }
            }
        }
    }
}