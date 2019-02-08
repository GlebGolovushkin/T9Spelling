namespace T9Spelling.InputReader
{
    using System;

    /// <summary>
    /// Helps to read data from command line tags
    /// </summary>
    internal static class CliParser
    {
        private static readonly string[] args;

        static CliParser()
        {
            args = Environment.GetCommandLineArgs();
        }

        /// <summary>
        /// Helps to get data from tag
        /// </summary>
        /// <param name="tag">Tag</param>
        /// <returns>Data</returns>
        internal static int GetTagIndex(string tag)
        {
            var index = Array.IndexOf(args, $"-{tag}");
            return index;
        }
    }
}