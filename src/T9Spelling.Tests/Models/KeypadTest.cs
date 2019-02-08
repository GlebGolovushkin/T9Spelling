namespace T9Spelling.Tests.T9SpellingConverterTests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using T9Spelling.Converter;
    using T9Spelling.Converter.Models.Keypad;

    [TestClass]
    public class KeypadTest
    {
        [TestMethod]
        public void TestKeypadLayoutSelectingDefault()
        {
            var t9Converter = new T9Converter();
            Assert.IsInstanceOfType(t9Converter.keypad, typeof(EnglishKeypad));
        }

        [TestMethod]
        public void TestKeypadLayoutSelectingRussian()
        {
            var t9Converter = new T9Converter(KeypadLayout.Russian);
            Assert.IsInstanceOfType(t9Converter.keypad, typeof(RussianKeypad));
        }
    }
}