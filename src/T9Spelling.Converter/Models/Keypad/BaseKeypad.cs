namespace T9Spelling.Converter.Models.Keypad
{
    using System.Collections.Generic;

    /// <summary>
    /// Abstract class for keypads
    /// </summary>
    internal abstract class BaseKeypad
    {
        internal IReadOnlyCollection<Key> Keys;

        /// <summary>
        /// Creates key
        /// </summary>
        /// <param name="key">Key symbol</param>
        /// <param name="characters">Characters in this key</param>
        /// <returns>Key</returns>
        protected Key CreateKey(char key, params char[] characters)
        {
            return new Key(key, characters);
        }
    }
}