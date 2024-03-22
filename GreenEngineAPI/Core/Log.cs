using System;

namespace GreenEngineAPI.Core
{
    public static class Log
    {
        public static bool EnableLogging = true;

        //message - string
        public static void Trace(string message = "" ,string sender = "GREEN ENGINE API CORE")
        {
            if (EnableLogging)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"[{DateTime.Now.ToString("T")}]{sender}: \"{message}\"");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Info(string message = "", string sender = "GREEN ENGINE API CORE")
        {
            if (EnableLogging)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"[{DateTime.Now.ToString("T")}]{sender}: \"{message}\"");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Warning(string message = "", string sender = "GREEN ENGINE API CORE")
        {
            if (EnableLogging)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[{DateTime.Now.ToString("T")}]{sender}: \"{message}\"");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Error(string message = "", string sender = "GREEN ENGINE API CORE")
        {
            if (EnableLogging)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{DateTime.Now.ToString("T")}]{sender}: \"{message}\"");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //For objects

        public static void Trace<T>(T obj)
        {
            if(EnableLogging)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"[{DateTime.Now.ToString("T")}]{obj.GetType().Name}: \"{obj.ToString()}\"");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Info<T>(T obj)
        {
            if (EnableLogging)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"[{DateTime.Now.ToString("T")}]{obj.GetType().Name}: \"{obj.ToString()}\"");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Warning<T>(T obj)
        {
            if (EnableLogging)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[{DateTime.Now.ToString("T")}]{obj.GetType().Name}: \"{obj.ToString()}\"");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Error<T>(T obj)
        {
            if (EnableLogging)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{DateTime.Now.ToString("T")}]{obj.GetType().Name}: \"{obj.ToString()}\"");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //Asking
        public static object Ask(string askText = "")
        {
            if (EnableLogging)
            {
                if (!string.IsNullOrEmpty(askText))
                {
                    Console.Write(askText);
                }
                return Console.ReadLine();
            }
            return null;
        }

        //Set console title
        public static void SetConsoleTitle(string title)
        {
            Console.Title = title;
        }
    }
}