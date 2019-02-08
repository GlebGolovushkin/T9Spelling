namespace T9Spelling.Converter.Models.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for input data
    /// </summary>
    public sealed class InputData
    {
        public readonly Dictionary<int, string> Cases;

        public readonly int Number;

        public InputData(int number, Dictionary<int, string> cases)
        {
            Number = number;
            Cases = cases;
        }
    }
}