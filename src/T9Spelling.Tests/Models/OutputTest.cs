namespace T9Spelling.Tests.T9SpellingConverterTests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using T9Spelling.Converter.Models.Data;

    [TestClass]
    public class OutputTest
    {
        [TestMethod]
        public void TestOutputDataCaseAdding()
        {
            var expected = "test";
            var outputData = new OutputData();
            outputData.AddCase(1, expected);
            var actual = outputData.Cases[1];
            Assert.AreEqual(actual, expected);
        }
    }
}