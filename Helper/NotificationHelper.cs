using System;

namespace GYM_System.Helper
{
    public static class NotificationHelper
    {
        public static void Info(string message,string resonOfEventInWord = "")
        {
            // Green For Add, Red for End, Yellow for Other
            if (resonOfEventInWord.Equals("Add",StringComparison.OrdinalIgnoreCase))
                Console.ForegroundColor = ConsoleColor.Green;
            else if (resonOfEventInWord.Equals("End",StringComparison.OrdinalIgnoreCase))
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Yellow;


            Console.WriteLine($"[Notification] {DateTime.Now}: {message}");
            Console.ResetColor();
        }
    }
}
