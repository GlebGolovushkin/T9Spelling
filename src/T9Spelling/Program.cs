namespace T9Spelling
{
    using InputReader;
    using System;
    using T9Helper;
    using UI;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var input = InputParser.GetInputData();
                var keyboardLayout = InputParser.GetKeyboardType();
                var outputFilePath = InputParser.GetOutputFilePath();
                var output = T9SpellingHelper.Translate(input, keyboardLayout);
                UIHelper.PrintResult(output, input, outputFilePath);
            }
            catch (Exception exception)
            {
                var message = exception.InnerException != null ? exception.InnerException.Message : exception.Message;
                ConsoleUI.PrintException(message);
            }
        }
    }
}