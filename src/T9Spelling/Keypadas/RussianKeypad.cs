namespace T9Spelling
{
    using System.Collections.Generic;

    public class RussianKeypad : IKeypad
    {
         public RussianKeypad()
        {
            var keys = new List<Key>
                        {
                            CreateKey(2, 'а', 'б', 'в', 'г'),
                            CreateKey(3, 'д', 'е', 'ж', 'з'),
                            CreateKey(4, 'и', 'й', 'к', 'л'),
                            CreateKey(5, 'м', 'н', 'о', 'п'),
                            CreateKey(6, 'р', 'с', 'т', 'у'),
                            CreateKey(7, 'ф', 'х', 'ц', 'ч'),
                            CreateKey(8, 'ш', 'щ', 'ъ', 'ы'),
                            CreateKey(9, 'ь', 'э', 'ю', 'я'),
                            CreateKey(0, ' ')
                        };

            this.Keys = keys;
        }
    }
}
