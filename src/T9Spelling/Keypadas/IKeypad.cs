namespace T9Spelling
{
    using System.Collections.Generic;

    public abstract class IKeypad
    {
        public IReadOnlyCollection<Key> Keys;

        protected Key CreateKey(int key, params char[] characters)
        {
            return new Key(key, characters);
        }
    }
}
