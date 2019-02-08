namespace T9Spelling.Converter.Models.Keypad
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class for key
    /// </summary>
    internal sealed class Key
    {
        internal readonly char Value;
        internal IReadOnlyCollection<char> Characters;

        internal Key(char value, IReadOnlyCollection<char> characters)
        {
            Characters = characters;
            Value = value;
        }

        /// <summary>
        /// Gets key index
        /// </summary>
        /// <param name="letter">letter</param>
        /// <returns>index</returns>
        internal int GetIndexOfLetter(char letter)
        {
            return Characters.ToList().IndexOf(letter);
        }
    }
}