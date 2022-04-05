using System;
using System.IO;
using Ex1.Types;

namespace Ex1
{
    public class LoggerService
    {
        public static void InitLog()
        {
            if (!File.Exists("log.txt")) File.Create("log.txt");
        }
        public static void Log(LogType logType, string logMessage)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.Write(
                    $"\r\n {logType} : {DateTime.Now.ToLongTimeString()}/{DateTime.Now.ToLongDateString()} : {logMessage}");
            }
        }

        public static void DumpLog()
        {
            using (StreamReader r = File.OpenText("log.txt"))
            {
                string? line;
                while ((line = r.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}