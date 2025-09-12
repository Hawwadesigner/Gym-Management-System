using System;

namespace GYM_System.Screens.Reports
{
    public static class ReportConsoleTitle
    {
        public static void PrintTitle(string title)
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            int width = 42;
            int padding = (width - title.Length) / 2;
            Console.WriteLine(new string(' ', padding) + title);
            Console.WriteLine("==========================================");
        }
    }
}
