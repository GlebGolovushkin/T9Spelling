namespace T9Spelling.Converter.Models.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for output data
    /// </summary>
    public sealed class OutputData
    {
        public Dictionary<int, string> Cases { get; } = new Dictionary<int, string>();

        /// <summary>
        /// Adds case
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        internal void AddCase(int key, string value)
        {
            Cases.Add(key, value);
        }
    }
}