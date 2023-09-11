using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Utilities
{
    public static class FileManager
    {
        public static string FileToString(String path) {
            string text = File.ReadAllText(path);
            return text;
        }
        public static void StringToFileReplace(String path,String text)
        {
            File.WriteAllText(path, text);
        }
    }

}
