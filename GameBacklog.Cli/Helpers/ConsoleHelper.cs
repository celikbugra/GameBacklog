using System.Threading;
using GameBacklog.Cli.Core;

namespace GameBacklog.Cli.Helpers
{
    internal static class ConsoleHelper
    {
        public static void TypeWriterLine(string text, int delay = Config.DefaultTypeWriterDelayMs)
        {
            foreach (char c in text)
            {
                Console.Write(c);

                Thread.Sleep(delay);
            }

            Console.WriteLine();
        }
    }
}