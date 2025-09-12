using System;

namespace GYM_System.Helper
{
    public static class InputHelper
    {
        public static int ReadInt(string prompotMessage = "", string invalidInputMessage = "Invalid Number, Enter again:\n")
        {
            Console.Write(prompotMessage);

            int Num = 0;
            while (!int.TryParse(Console.ReadLine(), out Num))
                Console.WriteLine(invalidInputMessage);

            return Num;
        }
        public static bool IsNumberBetween(int num, int from, int to)
        {
            return !(num < from || num > to);
        }
        public static int ReadIntNumberBetween(int from, int to, string outOfRangeMessage = "Number is not within range, enter again:\n")
        {
            int Num = ReadInt();
            while (!IsNumberBetween(Num, from, to))
            {
                Console.WriteLine(outOfRangeMessage);
                Num = ReadInt();
            }
            return Num;
        }

        public static decimal ReadDecimal(string prompotMessage = "", string invalidInputMessage = "Invalid Number, Enter again:\n")
        {
            Console.Write(prompotMessage);

            decimal Num = 0;
            while (!decimal.TryParse(Console.ReadLine(), out Num))
                Console.WriteLine(invalidInputMessage);

            return Num;
        }

        public static string ReadString(string prompotMessage = "", string InvalidInputMessage = "Invalid String, Enter again:\n")
        {
            Console.Write(prompotMessage);
            string? input = Console.ReadLine();

            while (int.TryParse(input, out _))
            {
                Console.WriteLine(InvalidInputMessage);
                Console.Write(prompotMessage);
                input = Console.ReadLine();
            }
            return input ?? "";
        }

        public static T ReadEnumOrKeep<T>(string prompt, T CurrentValue, bool IsUpdate = false) where T : Enum
        {
            var input = ReadString(prompt + $"{(IsUpdate? $"(leave empty to keep '{CurrentValue}')" : "")}: ");
            if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int val) && Enum.IsDefined(typeof(T), val))
                return (T)Enum.ToObject(typeof(T), val);
            return CurrentValue; // if Not updated 
        }

        public static bool? ReadYesOrNo(string prompotMessage = "", string InvalidInputMessage = "Invalid answer, please enter y or n:\n")
        {
            Console.Write(prompotMessage);
            string? input = Console.ReadLine().Trim().ToLower();
            
            while (!string.IsNullOrWhiteSpace(input) && input != "y" && input != "n") 
            {
                Console.WriteLine(InvalidInputMessage);
                Console.Write(prompotMessage);
                input = Console.ReadLine().Trim().ToLower();
            }

            if (string.IsNullOrWhiteSpace(input)) return null;

            return input == "y";
        }

        public static DateTime ReadDate(string message = "")
        {
            Console.Write(message);
            DateTime result;
            while (!DateTime.TryParse(Console.ReadLine(), out result))
                Console.Write("Invalid date, try again: ");
            return result;
        }
        public static DateTime CalculateEndDate(DateTime startDate, enPlanType plan) 
            => plan == enPlanType.Monthly? startDate.AddMonths(1) : startDate.AddDays(DateTime.IsLeapYear(startDate.Year)? 366 : 365);
    }
}
