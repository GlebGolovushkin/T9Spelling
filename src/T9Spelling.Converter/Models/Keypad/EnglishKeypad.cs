namespace T9Spelling.Converter.Models.Keypad
{
    using System.Collections.Generic;

    /// <summary>
    /// English keyboard type
    /// </summary>
    internal sealed class EnglishKeypad : BaseKeypad
    {
        internal EnglishKeypad()
        {
            var keys = new List<Key>
            {
                CreateKey('2', 'a', 'b', 'c'),
                CreateKey('3', 'd', 'e', 'f'),
                CreateKey('4', 'g', 'h', 'i'),
                CreateKey('5', 'j', 'k', 'l'),
                CreateKey('6', 'm', 'n', 'o'),
                CreateKey('7', 'p', 'q', 'r', 's'),
                CreateKey('8', 't', 'u', 'v'),
                CreateKey('9', 'w', 'x', 'y', 'z'),
                CreateKey('0', ' ')
            };

            Keys = keys;
        }
    }
}