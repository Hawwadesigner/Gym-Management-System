using GYM_System.Helper;
using GYM_System.Models;
using GYM_System.Screens.Reports.Core;
using GYM_System.Screens.Reports.PDF;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Reports
{
    public static class ReportMenuScreen
    {
        public static void Show(ReportService reportService)
        {
            var reports = ReportsCatalog.GetAllReports(reportService);

            while (true)
            {
                ConsoleUIHelper.ShowMenu("REPORT MENU", new List<string>
                {
                    "Members Whose Subscriptions Are About to Expire",
                    "Members List by Trainer",
                    "Revenue In Specific Month",
                    "Most Active Attendance-Committed Members",
                    "Main Menu"
                });

                var option = InputHelper.ReadIntNumberBetween(1, 5).ToString();

                switch (option)
                {
                    case "1":
                        var report1 = (ReportDifinationModel<SubscriptionModel>)reports[0];
                        var data1 = report1.GetData(reportService);
                        ReportConsoleTitle.PrintTitle(report1.Title);
                        report1.RenderConsole(data1);
                        ReportPdfGenerator.ExportReportToPdf(report1.Title,data1,report1.RenderPDF);
                        break;

                    case "2":
                        var report2 = (ReportDifinationModel<TrainerModel>)reports[1];
                        var data2 = report2.GetData(reportService);
                        ReportConsoleTitle.PrintTitle(report2.Title);
                        report2.RenderConsole(data2);
                        ReportPdfGenerator.ExportReportToPdf(report2.Title,data2,report2.RenderPDF);
                        break;

                    case "3":
                        var report3 = (ReportDifinationModel<Dictionary<string, decimal>>)reports[2];
                        Console.WriteLine("Enter month (1-12): ");  // Ask User
                        int month = InputHelper.ReadIntNumberBetween(1, 12);
                        report3.Title = $"REVENUE – MONTH {month}";

                        var data3 = new List<Dictionary<string, decimal>> { reportService.GetRevenueInSpecificMonth(month) };
                        ReportConsoleTitle.PrintTitle(report3.Title);
                        report3.RenderConsole(data3);
                        ReportPdfGenerator.ExportReportToPdf(report3.Title, data3, report3.RenderPDF);
                        break;

                    case "4":
                        var report4 = (ReportDifinationModel<AttendanceReportModel>)reports[3];
                        var data4 = report4.GetData(reportService);
                        ReportConsoleTitle.PrintTitle(report4.Title);
                        report4.RenderConsole(data4);
                        ReportPdfGenerator.ExportReportToPdf(report4.Title,data4,report4.RenderPDF);
                        break;

                    case "5": return;
                }
                Console.WriteLine("\n\nPress any key to return to Report Menu Screen...");
                Console.ReadKey();
            }
        }
    }
}
