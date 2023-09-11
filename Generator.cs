using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextCopy;

namespace SeleniumTestProject.Utilities
{
    public static class Generator
    {
        public static string SaIdGenerator(string dob, bool male, bool citizen)
        {
            Random rnd = new ();
            int gender = rnd.Next(5) + (male ? 5 : 0);
            int citBit = !citizen ? 1 : 0;
            string random = Convert.ToString(rnd.Next(1000));

            if (Convert.ToInt32(random) < 10) random = "00" + random;
            else if (Convert.ToInt32(random) < 100) random = "0" + random;

            string total = "" + dob + Convert.ToString(gender) + random + Convert.ToString(citBit) + "8";
            total += GenerateLuhnDigit(total);

            return total;
        }
        public static string GenerateLuhnDigit(string inputString)
        {
            int total = 0;
            int count = 0;
            for (int i = 0; i < inputString.Length; i++)
            {
                int multiple = count % 2 + 1;
                count++;
                int temp = multiple * (inputString[i] - '0');
                if(temp >= 10)
                {
                    temp = Convert.ToInt32(Math.Floor((double)temp / 10) + (temp % 10));
                }
                total += temp;
            }
            total = (total * 9) % 10;
            return Convert.ToString(total);
        }
    }
}
