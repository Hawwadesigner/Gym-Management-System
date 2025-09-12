using GYM_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYM_System.Screens.Attendance
{
    public static class ViewAttendanceScreen
    {
        public static void Show(IEnumerable<AttendanceModel> attendances)
        {
            Console.Clear();
            Console.WriteLine("┌────┬───────────┬─────────────────────────┬────────────┐");
            Console.WriteLine("│ ID │ Member Id │ Member Name             │ Date       │");
            Console.WriteLine("├────┼───────────┼─────────────────────────┼────────────┤");

            if (!attendances.Any())
            {
                Console.WriteLine("│                 No Attendance Records Found!          │");
                Console.WriteLine("└────┴───────────┴─────────────────────────┴────────────┘");
                return;
            }

            var sb = new StringBuilder();

            foreach (var att in attendances)
            {
                sb.AppendLine($"│{att.Id.ToString().PadLeft(3)} " +
                              $"│{att.MemberId.ToString().PadLeft(9)} " +
                              $"│{att.Member.FullName.PadRight(23).Substring(0, Math.Min(23, att.Member.FullName.Length))}" +
                              $"│{att.Date:yyyy/MM/dd} │");
            }
            Console.WriteLine("└────┴───────────┴─────────────────────────┴────────────┘");
        }
    }
}
