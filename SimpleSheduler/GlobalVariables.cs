using System;
using System.IO;

namespace SimpleSheduler
{
    internal class GlobalVariables
    {
        public static readonly string dbPath;
        public static readonly string logFilePath;
        static GlobalVariables()
        {
            dbPath = Path.Combine(Environment.CurrentDirectory, "Sheduler");
            logFilePath = Environment.CurrentDirectory + "\\Info.log";
        }
    }
}
