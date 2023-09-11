using OpenQA.Selenium;
using System;

namespace SeleniumTestProject.Utilities
{
    public class RandonTextGenerator
    {
        public IWebDriver _driver;

        public RandonTextGenerator(IWebDriver driver)
        {
            _driver = driver;
        }

        public static string RandomStringGenerator()
        {
            Random rand = new();

            int stringlen = rand.Next(4, 10);
            int randValue;
            string str = "";
            char letter;

            for (int i = 0; i < stringlen; i++)
            {
                randValue = rand.Next(0, 26);
                letter = Convert.ToChar(randValue + 65);
                str += letter;
            }
            return str;
        }
        public static string RandomAlphanumbericString(int length)
        {
            Random random = new();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomNumber(int length)
        {
            Random random = new();
            const string chars = "123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
