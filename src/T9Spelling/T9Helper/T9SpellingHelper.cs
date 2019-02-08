namespace T9Spelling.T9Helper
{
    using Converter;
    using Converter.Models.Data;
    using Converter.Models.Keypad;

    /// <summary>
    /// Helper class to translate data
    /// </summary>
    internal static class T9SpellingHelper
    {
        /// <summary>
        /// Translates data
        /// </summary>
        /// <param name="inputData">input data</param>
        /// <param name="keypadLayout">keypad type</param>
        /// <returns>output data</returns>
        internal static OutputData Translate(InputData inputData, KeypadLayout keypadLayout = KeypadLayout.English)
        {
            var translator = new T9Converter(keypadLayout);
            var output = translator.Translate(inputData);

            return output;
        }
    }
}