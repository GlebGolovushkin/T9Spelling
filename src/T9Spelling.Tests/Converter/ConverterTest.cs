namespace T9Spelling.Tests.Converter
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using T9Helper;
    using T9Spelling.Converter;
    using T9Spelling.Converter.Models.Data;
    using T9Spelling.Converter.Models.Keypad;

    [TestClass]
    public class ConverterTest
    {
        [DataTestMethod]
        [DataRow("2", 'a')]
        [DataRow("22", 'b')]
        [DataRow("333", 'f')]
        public void TestGetEnglishLetterCode(string expected, char letter)
        {
            var t9Converter = new T9Converter();
            var actual = t9Converter.GetLetterCode(letter);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("2", 'а')]
        [DataRow("33", 'е')]
        [DataRow("4", 'и')]
        public void TestGetRussianLetterCode(string expected, char letter)
        {
            var t9Converter = new T9Converter(KeypadLayout.Russian);
            var actual = t9Converter.GetLetterCode(letter);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Failed to get code for 'b' letter.")]
        public void TestExceptionEnglishLetterCode()
        {
            var t9Converter = new T9Converter(KeypadLayout.Russian);
            t9Converter.GetLetterCode('b');
        }

        [DataTestMethod]
        [DataRow("Case #1: 83377778", "test")]
        [DataRow("Case #1: 44466788 8", "input")]
        [DataRow("Case #1: 33 33 33 33", "eeee")]
        public void TestGetEnglishMessageCode(string expected, string message)
        {
            var t9Converter = new T9Converter();
            var actual = t9Converter.GetMessageCode(1, message);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("Case #1: 6663366 666", "тест")]
        [DataRow("Case #1: 222775553", "вход")]
        [DataRow("Case #1: 2222 2222 2222 2222", "гггг")]
        public void TestGetRussianMessageCode(string expected, string message)
        {
            var t9Converter = new T9Converter(KeypadLayout.Russian);
            var actual = t9Converter.GetMessageCode(1, message);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("Case #1: 83377778", "test")]
        [DataRow("Case #1: 44466788 8", "input")]
        [DataRow("Case #1: 33 33 33 33", "eeee")]
        public void TestTranslator(string expected, string message)
        {
            var cases = new Dictionary<int, string>();
            cases.Add(1, message);
            var input = new InputData(1, cases);
            var actual = T9SpellingHelper.Translate(input, KeypadLayout.English).Cases[1];
            Assert.AreEqual(expected, actual);
        }
    }
}