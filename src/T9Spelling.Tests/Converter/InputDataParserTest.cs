namespace T9Spelling.Tests.Converter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using InputReader;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using T9Helper;
    using T9Spelling.Converter.Models.Data;
    using T9Spelling.Converter.Models.Keypad;
    using UI;

    [TestClass]
    public class InputDataParserTest
    {
        private string CreateTmpFile(int casesNumber, string number = null, string message = null)
        {
            number = number ?? casesNumber.ToString();
            message = message ?? "text";
            var path = Path.GetTempFileName();
            var sw = File.CreateText(path);
            sw.WriteLine(number);
            for (var i = 0; i < casesNumber; i++)
            {
                sw.WriteLine(message);
            }

            sw.Close();
            return path;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Invalid number of cases in input or output data.")]
        public void TestFilePrintResultWrongArguments()
        {
            var cases = new Dictionary<int, string>();
            var input = new InputData(1, cases);
            var output = new OutputData();
            output.AddCase(2, "test");
            ConsoleUI.PrintResult(output, input);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Failed to parse number of messages.")]
        public void TestCliWrongTypeNumber()
        {
            string[] args =
            {
                "-n",
                "test"
            };
            var reader = new CliReader(args);
            reader.ReadData();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Failed to take 3 message.")]
        public void TestCliWrongMessagesNumber()
        {
            string[] args =
            {
                "-n",
                "3",
                "-m",
                "test",
                "test"
            };
            var reader = new CliReader(args);
            reader.ReadData();
        }

        [DataTestMethod]
        [DataRow("Case #1: 83377778", "test")]
        [DataRow("Case #1: 44466788 8", "input")]
        [DataRow("Case #1: 33 33 33 33", "eeee")]
        public void TestFileConverter(string expected, string message)
        {
            var path = CreateTmpFile(1, "1", message);
            var reader = new ReaderInput(path);
            var input = reader.ReadData();
            var actual = T9SpellingHelper.Translate(input, KeypadLayout.English).Cases[1];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Failed to parse messages number from file.")]
        public void TestFileWrongNumberType()
        {
            var path = CreateTmpFile(1, "test");
            var reader = new ReaderInput(path);
            var input = reader.ReadData();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Failed to get 2 messages.")]
        public void TestFileWrongCasesNumber()
        {
            var path = CreateTmpFile(1, "2");
            var reader = new ReaderInput(path);
            var input = reader.ReadData();
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException),
            "Failed to find file in 'test' path.")]
        public void TestFileDoesNotExist()
        {
            var wrongPath = "test";
            var reader = new ReaderInput(wrongPath);
            var input = reader.ReadData();
        }
    }
}