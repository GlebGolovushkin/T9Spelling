namespace T9Spelling.Converter.Models.Keypad
{
    using System.Collections.Generic;

    /// <summary>
    /// English keyboard type
    /// </summary>
    internal sealed class RussianKeypad : BaseKeypad
    {
        internal RussianKeypad()
        {
            var keys = new List<Key>
            {
                CreateKey('2', 'а', 'б', 'в', 'г'),
                CreateKey('3', 'д', 'е', 'ж', 'з'),
                CreateKey('4', 'и', 'й', 'к', 'л'),
                CreateKey('5', 'м', 'н', 'о', 'п'),
                CreateKey('6', 'р', 'с', 'т', 'у'),
                CreateKey('7', 'ф', 'х', 'ц', 'ч'),
                CreateKey('8', 'ш', 'щ', 'ъ', 'ы'),
                CreateKey('9', 'ь', 'э', 'ю', 'я'),
                CreateKey('0', ' ')
            };

            Keys = keys;
        }
    }
}