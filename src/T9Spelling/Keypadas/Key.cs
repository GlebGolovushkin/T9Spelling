namespace T9Spelling
{
    using System.Collections.Generic;
    using System.Linq;

    public class Key
    {
        public Key(int value, IReadOnlyCollection<char> charackters)
        {
            this.Charackters = charackters;
            this.Value = value;
        }

        public readonly int Value;
        public IReadOnlyCollection<char> Charackters;

        public int GetIndexOfLetter(char letter)
        {
            return Charackters.ToList().IndexOf(letter);
        }
    }
}
