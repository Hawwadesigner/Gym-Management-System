using System;
using Microsoft.Extensions.Options;

namespace GYM_System.Helper
{
    public static class ConsoleUIHelper
    {
        public static void ShowMenu(string title, List<string>options)
        {
            Console.Clear();
            int width = 42;

            // Header
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine($"{title.PadLeft((width+ title.Length)/2).PadRight(width)} ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");

            // Options
            for (int i = 0; i < options.Count; i++)
            {
                string line = $"[{i + 1}] {options[i]}";
                if (line.Length > width)
                    line = line.Substring(0, width);
                Console.WriteLine($"║{line.PadRight(width)}║");
            }

            // Footer
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("\n-> Select an option: ");
        }
    }
}
