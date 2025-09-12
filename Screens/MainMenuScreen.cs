using GYM_System.Data;
using GYM_System.Helper;
using GYM_System.Screens.Member;
using GYM_System.Screens.Member.Attendance;
using GYM_System.Screens.Member.Subscription;
using GYM_System.Screens.Reports;
using GYM_System.Screens.Trainer;
using GYM_System.Services;
using System;

namespace GYM_System.Screens
{
    public static class MainMenuScreen
    {
        public static void Show()
        {
            // Dependance Injection
            using var context = new AppDbContext();
            var memberService = new MemberService(context);
            var trainerService = new TrainerService(context);
            var subscriptionService = new SubscriptionService(context);
            var subscriptionChecker = new SubscriptionChecker(); // This is Timer Not CRUD 
            var attendance = new AttendanceService(context);
            var reportService = new ReportService(context);
                 
            while (true)
            {
                ConsoleUIHelper.ShowMenu("MAIN MENU SCREEN", new List<string>
                {
                    "Manage Members",
                    "Manage Attendance",
                    "Manage Subscriptions",
                    "Manage Trainers",
                    "Reports",
                    "Exit"
                });
                var options = InputHelper.ReadIntNumberBetween(1, 6).ToString();

                switch (options)
                {
                    case "1": MembersManagementMenu.Show(memberService); break;
                    case "2": AttendanceManagementMenu.Show(attendance, memberService); break;
                    case "3": SubscriptionsManagementMenu.Show(subscriptionChecker,subscriptionService, memberService); break;
                    case "4": TrainersManagementMenu.Show(trainerService); break;
                    case "5": ReportMenuScreen.Show(reportService); break;
                    case "6": Console.WriteLine("\n\nThanks for using GYM Management System!\nOrganization is the Key to Power\nGoodBye.");
                              subscriptionChecker.StopChecking();return;
                }
                Console.WriteLine("\n\nPress any key to return to Main Menu Screen...");
                Console.ReadKey();
            }
        }
    }
}
