using GYM_System.Services;
using QuestPDF.Fluent;
using System;

namespace GYM_System.Screens.Reports.Core
{
    public class ReportDifinationModel<T>
    {
        public string Title { get; set; }
        public Func<ReportService, IEnumerable<T>> GetData { get; set; }
        public Action<IEnumerable<T>> RenderConsole { get; set; }
        public Action<ColumnDescriptor, IEnumerable<T>> RenderPDF {get; set;}
    }
}
