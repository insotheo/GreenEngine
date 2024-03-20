using System;

namespace GreenEngine.Core
{
    public static class Log
    {

        //For string messages
        public static void Trace(string sender, string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{DateTime.Now.ToString("T")}]({sender}): \"{message}\"");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Info(string sender, string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now.ToString("T")}]({sender}): \"{message}\"");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Warning(string sender, string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{DateTime.Now.ToString("T")}]({sender}): \"{message}\"");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Error(string sender, string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{DateTime.Now.ToString("T")}]({sender}): \"{message}\"");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //For objects
        public static void Trace<T>(T obj)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{DateTime.Now.ToString("T")}]({obj.GetType().Name}): \"{obj.ToString()}\"");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Info<T>(T obj)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now.ToString("T")}]({obj.GetType().Name}): \"{obj.ToString()}\"");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Warning<T>(T obj)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{DateTime.Now.ToString("T")}]({obj.GetType().Name}): \"{obj.ToString()}\"");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Error<T>(T obj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{DateTime.Now.ToString("T")}]({obj.GetType().Name}): \"{obj.ToString()}\"");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
