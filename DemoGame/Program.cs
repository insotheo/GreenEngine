using GreenEngine.Core;

namespace DemoGame
{
    internal class Program
    {
        static void Main()
        {
            Log.Trace("GREEN ENGINE CORE", "Hello, World!");
            Log.Info("GREEN ENGINE CORE", "Hello, World!");
            Log.Warning("GREEN ENGINE CORE", "Hello, World!");
            Log.Error("GREEN ENGINE CORE", "Hello, World!");
            while (true) { }
        }
    }
}
