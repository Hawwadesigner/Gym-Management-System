using GYM_System.Helper;
using GYM_System.Screens.Attendance;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Member.Attendance
{
    public static class AttendanceManagementMenu
    {
        public static void Show(AttendanceService attendanceService,MemberService memberService)
        {
            // Add Subscriber -> One time
            attendanceService.OnAttendanceRecorded += (att) =>
            Console.WriteLine($"[Notification] Attendance recorded for {att.Member.FullName} at {att.Date}");

            while (true) 
            {
                ConsoleUIHelper.ShowMenu("ATTENDANCE MENU", new List<string>
                {
                    "Record Attendance",
                    "View Attendance",
                    "Main Menu"
                });

                var options = InputHelper.ReadIntNumberBetween(1, 2).ToString();

                switch (options)
                {
                    case "1": RecordAttendanceScreen.Show(memberService,attendanceService); break;
                    case "2": ViewAttendanceScreen.Show(attendanceService.GetAllLazy()); break;
                    case "3": return;
                }
                Console.WriteLine("\n\nPress any key to return to Attendance Menu Screen...");
                Console.ReadKey();
            }
        }
    }
}
