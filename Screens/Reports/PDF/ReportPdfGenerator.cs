using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using System;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure;

namespace GYM_System.Screens.Reports.PDF
{
    public static class ReportPdfGenerator
    {
        public static void ExportReportToPdf<T>(string title, IEnumerable<T> data, Action<ColumnDescriptor,IEnumerable<T>> renderContent)
        {
            // Create
            var doc = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Header().Text(title).FontSize(18).Bold().AlignCenter();
                    page.Content().Column(col => { renderContent(col, data); });
                    page.Footer().AlignCenter().Text(txt => { txt.Span("Genereted on ").Italic(); txt.Span(DateTime.Now.ToString("yyyy/MM/dd")); });
                });
            });

            // Path
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),$"{title.Replace(" ", "_")}.pdf");
            doc.GeneratePdf(filePath);
            Console.WriteLine($"\n\nPDF Genereted : {filePath}");
        }
    }
}

