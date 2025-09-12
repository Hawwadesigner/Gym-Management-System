using System;
using GYM_System.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace GYM_System.Screens.Reports.PDF
{
    public class ReportPdfRenderers
    {
        public static void RenderMembersWhoseSubscriptionsAreAboutToExpirePDF(ColumnDescriptor columnDescriptor, IEnumerable<SubscriptionModel> data)
        {
            columnDescriptor.Item().Table(table =>
            {
                table.ColumnsDefinition(column=>
                {
                    column.RelativeColumn(3);
                    column.RelativeColumn(2);
                });

                table.Header(header =>
                {
                    header.Cell().Text("Member Name").Bold();
                    header.Cell().Text("Expiry Date").Bold();
                });

                foreach(var s in data)
                {
                    table.Cell().Text(s.Member.FullName);
                    table.Cell().Text(s.DateSubscription.EndDate.ToString("yyyy/MM/dd"));
                }
            });
        }
        
        public static void RenderMembersListbyTrainerPDF(ColumnDescriptor columnDescriptor,IEnumerable<TrainerModel> data)
        {
            foreach(var t in data)
            {
                columnDescriptor.Item().Text($"Trainer: {t.FullName}").Bold();
                columnDescriptor.Item().LineHorizontal(1);

                if (t.Members != null && t.Members.Any())
                {
                    columnDescriptor.Item().Table(table =>
                    {
                        table.ColumnsDefinition(column =>
                        {
                            column.RelativeColumn(1);
                        });
                        foreach (var m in t.Members)
                            table.Cell().Text(m.FullName);
                    });
                }
                else
                    columnDescriptor.Item().Text("No Members");
                columnDescriptor.Item().LineHorizontal(1);
            }
        }
        
        public static void RenderRevenueInSpecificMonthPDF(ColumnDescriptor columnDescriptor, Dictionary<string, decimal> data)
        {
            columnDescriptor.Item().Table(table =>
            {
                table.ColumnsDefinition(column =>
                {
                    column.RelativeColumn(2);
                    column.RelativeColumn(2);
                });

                table.Header(header =>
                {
                    header.Cell().Text("Service Level").Bold();
                    header.Cell().Text("Revenue").Bold();
                });

                foreach(var r in data)
                {
                    table.Cell().Text(r.Key);
                    table.Cell().Text(r.Value.ToString("C2"));
                }
            });
        }
        
        public static void RenderMostActiveAttendanceCommittedMembersPDF(ColumnDescriptor columnDescriptor,IEnumerable<AttendanceReportModel> data)
        {
            columnDescriptor.Item().Table(table =>
            {
                table.ColumnsDefinition(column =>
                {
                    column.RelativeColumn(3);
                    column.RelativeColumn(1);
                });

                table.Header(header =>
                {
                    header.Cell().Text("Member Name").Bold();
                    header.Cell().Text("Attendance").Bold();
                });

                foreach(var m in data)
                {
                    table.Cell().Text(m.MemberName);
                    table.Cell().Text(m.AttendanceCount.ToString());
                }
            });
        }
    }
}
