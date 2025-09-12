using GYM_System.Helper;
using GYM_System.Models;
using GYM_System.Screens.Reports.PDF;
using GYM_System.Services;

namespace GYM_System.Screens.Reports.Core
{
    public static class ReportsCatalog
    {
        public static List<object> GetAllReports(ReportService reportService)
        {
            return new List<object>
            {
                // 1. MembersWhoseSubscriptionsAreAboutToExpire
                new ReportDifinationModel<SubscriptionModel>
                {
                    Title = "MEMBERS – SUBSCRIPTIONS EXPIRING SOON",
                    GetData = s=>s.GetMembersWhoseSubscriptionsAreAboutToExpire(),
                    RenderConsole =  ReportConsoleRenderers.RenderMembersWhoseSubscriptionsAreAboutToExpireConsole,
                    RenderPDF = ReportPdfRenderers.RenderMembersWhoseSubscriptionsAreAboutToExpirePDF
                },

                // 2. MembersListbyTrainer
                new ReportDifinationModel<TrainerModel>
                {
                    Title = "TRAINERS – MEMBERS LIST",
                    GetData = s=>s.GetMembersListbyTrainer(),
                    RenderConsole =  ReportConsoleRenderers.RenderMembersListbyTrainerConsole,
                    RenderPDF = ReportPdfRenderers.RenderMembersListbyTrainerPDF
                },

                // 3. RevenueInSpecificMonth
                new ReportDifinationModel<Dictionary<string ,decimal>>
                {
                    Title = "REVENUE – MONTH {month}",
                    GetData = s => null,
                    RenderConsole = dataList =>
                    {
                        foreach(var data in dataList)
                        ReportConsoleRenderers.RenderRevenueInSpecificMonthConsole(data);
                    },
                    RenderPDF = (col,dataList) =>
                    {
                        foreach(var data in dataList)
                        ReportPdfRenderers.RenderRevenueInSpecificMonthPDF(col, data);
                    }
                },

                // 4. MostActiveAttendanceCommittedMembers
                new ReportDifinationModel<AttendanceReportModel>
                {
                    Title = "MEMBERS – HIGHLY COMMITED",
                    GetData = s=>s.GetMostActiveAttendanceCommittedMembers(),
                    RenderConsole =  ReportConsoleRenderers.RenderMostActiveAttendanceCommittedMembersConsole,
                    RenderPDF = ReportPdfRenderers.RenderMostActiveAttendanceCommittedMembersPDF
                }
            };
        }
    }
}


