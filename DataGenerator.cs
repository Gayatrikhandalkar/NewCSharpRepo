using System.Text;
using System;

namespace SeleniumTestProject.Utilities
{
    public static class DataGenerator
    {
        public static string KeyWordManager(string key)
        {
            string mystring = "";

            switch (key)
            {
                case "**GENERATEFIRSTNAME":
                case "**GENERATELASTNAME":
                    mystring = DataGenerator.GetString(10, 2);
                    mystring = string.Concat(mystring.Substring(0, 1).ToUpper(), mystring.AsSpan(1));
                    break;
                case "**GENERATEEMAIL":
                    mystring = DataGenerator.GetString(20, 3);
                    mystring = mystring + "@fakeEmail.co.za";
                    break;
                case "**GENERATEPHONENUMBER":
                    mystring = "67" + DataGenerator.GetString(7, 1);
                    break;
                case "**GENERATEKENYAKARPINNO":
                    mystring = "P" + DataGenerator.GetString(9, 1) + DataGenerator.GetString(1, 2);
                    break;
                case "**GENERATESPECIALCUSTOMERID":
                    mystring =DataGenerator.GetString(14, 1);
                    break;
            }
            return mystring;
        }

        public static String GetString(int n, int type)
        {
            String mystring = "";
            Random random = new();

            switch (type)
            {
                case 1:
                    mystring = "123456789";
                    break;
                case 2:
                    mystring = "abcdefghijklmnopqrstuvxyz";
                    break;
                case 3:
                    mystring = "abcdefghijklmnopqrstuvxyz0123456789";
                    break;
            }

            // create StringBuffer size of AlphaNumericString
            StringBuilder sb = new (n);

            for (int i = 0; i < n; i++)
            {
                // generate a random number between
                // 0 to AlphaNumericString variable length
                int index = random.Next(0, mystring.Length);

                // add Character one by one in end of sb
                sb.Append(mystring[index]);
            }
            return sb.ToString();
        }
    }
}
