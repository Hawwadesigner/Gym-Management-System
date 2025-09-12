using GYM_System.Helper;
using GYM_System.Models;
using GYM_System.Services;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;

namespace GYM_System.Screens.Reports
{
    public static class ReportConsoleRenderers
    {
        public static void RenderMembersWhoseSubscriptionsAreAboutToExpireConsole(IEnumerable<SubscriptionModel> data)
        {
            Console.WriteLine("{0,-30} | {1,15}", "Member Name", "Expiry Date"); // header
            Console.WriteLine(new string('-', 50));

            foreach (var s in data)
                Console.WriteLine("{0,-30} | {1,15:yyyy/MM/dd}", s.Member.FullName, s.DateSubscription.EndDate.Date);// data

            Console.WriteLine(new string('-', 50)); // footer
        }
        
        public static void RenderMembersListbyTrainerConsole(IEnumerable<TrainerModel> data)
        {
            foreach (var t in data) // for trainer
            {
                Console.WriteLine($"Trainer Name:  {t.FullName}"); // header
                Console.WriteLine(new string('-', 35));

                if (t.Members != null && t.Members.Any()) // data
                {
                    foreach (var m in t.Members) // for members
                        Console.WriteLine($"-{m.FullName}");
                }
                else
                    Console.WriteLine("\nNo Members");

                Console.WriteLine(new string('-', 35)); // footer
            }
        }
        
        public static void RenderRevenueInSpecificMonthConsole(Dictionary<string, decimal> data)
        {
            Console.WriteLine("{0,15} | {1,15}", "Service Level", "Revenue"); // header
            Console.WriteLine(new string('-', 38));

            foreach (var r in data)
            {
                Console.WriteLine("{0,15} | {1,15:C2}", r.Key, r.Value); // data
            }
            Console.WriteLine(new string('-', 35)); // footer
        }
        
        public static void RenderMostActiveAttendanceCommittedMembersConsole(IEnumerable<AttendanceReportModel> data)
        {
            Console.WriteLine("{0,30} | {1,10}", "Member Name", "Attendance"); // header
            Console.WriteLine(new string('-', 45));

            foreach (var m in data)
            {
                Console.WriteLine("{0,30} | {1,10}", m.MemberName, m.AttendanceCount);// data
            }
            Console.WriteLine(new string('-', 45)); // footer
        }
    }

}
