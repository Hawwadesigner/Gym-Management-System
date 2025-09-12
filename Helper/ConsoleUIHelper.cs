using System;
using Microsoft.Extensions.Options;

namespace GYM_System.Helper
{
    public static class ConsoleUIHelper
    {
        public static void ShowMenu(string title, List<string>options)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine($"{title.PadLeft((40 + title.Length)/2).PadRight(40)} ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"║[{i+1}] {options[i].PadLeft(38)}║");
            }
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("\n-> Select an option: ");
        }
    }
}
