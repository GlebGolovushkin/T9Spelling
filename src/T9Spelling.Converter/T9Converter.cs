namespace T9Spelling.Converter
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Models.Data;
    using Models.Keypad;

    /// <summary>
    /// Class presets t9 converter functionality
    /// </summary>
    public sealed class T9Converter
    {
        private const char SPACE_LETTER = ' ';
        internal readonly BaseKeypad keypad;

        public T9Converter(KeypadLayout keypadLayout = KeypadLayout.English)
        {
            switch (keypadLayout)
            {
                case KeypadLayout.Russian:
                {
                    keypad = new RussianKeypad();
                    break;
                }
                default:
                {
                    keypad = new EnglishKeypad();
                    break;
                }
            }
        }

        /// <summary>
        /// Translates input data in output
        /// </summary>
        /// <param name="input">Input data</param>
        /// <returns>Output data</returns>
        public OutputData Translate(InputData input)
        {
            var result = new OutputData();
            Parallel.ForEach(input.Cases,
                message => { result.AddCase(message.Key, GetMessageCode(message.Key, message.Value)); });

            return result;
        }

        /// <summary>
        /// Gets message code
        /// </summary>
        /// <param name="lineNumber">Number of line with message</param>
        /// <param name="line">Line text</param>
        /// <returns>Message code</returns>
        internal string GetMessageCode(int lineNumber, string line)
        {
            var sb = new StringBuilder($"Case #{lineNumber}: ");
            var lastDigit = -1;
            foreach (var symbol in line)
            {
                var symbolCode = GetLetterCode(symbol);
                var digit = int.Parse(symbolCode) % 10;
                if (digit == lastDigit)
                {
                    sb.Append(SPACE_LETTER);
                }

                sb.Append(symbolCode);
                lastDigit = digit;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gets letter code
        /// </summary>
        /// <param name="letter">Letter</param>
        /// <returns>Letter code</returns>
        internal string GetLetterCode(char letter)
        {
            foreach (var key in keypad.Keys)
            {
                var index = key.GetIndexOfLetter(letter);
                if (index >= 0)
                {
                    return new string(key.Value, index + 1);
                }
            }

            throw new ArgumentException($"Failed to get code for '{letter}' letter.");
        }
    }
}