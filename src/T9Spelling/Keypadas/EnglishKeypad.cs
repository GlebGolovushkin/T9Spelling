namespace T9Spelling
{
    using System.Collections.Generic;

    public class EnglishKeypad : IKeypad
    {
         public EnglishKeypad()
        {
            var keys = new List<Key>
                        {
                            CreateKey(2, 'a', 'b', 'c'),
                            CreateKey(3, 'd', 'e', 'f'),
                            CreateKey(4, 'g', 'h', 'i'),
                            CreateKey(5, 'j', 'k', 'l'),
                            CreateKey(6, 'm', 'n', 'o'),
                            CreateKey(7, 'p', 'q', 'r', 's'),
                            CreateKey(8, 't', 'u', 'v'),
                            CreateKey(9, 'w', 'x', 'y', 'z'),
                            CreateKey(0, ' ')
                        };

            this.Keys = keys;
        }
    }
}
