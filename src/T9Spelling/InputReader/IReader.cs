namespace T9Spelling.InputReader
{
    using Converter.Models.Data;

    /// <summary>
    /// Interface for data reading
    /// </summary>
    internal interface IReader
    {
        /// <summary>
        /// Read data
        /// </summary>
        /// <returns>Input data</returns>
        InputData ReadData();
    }
}