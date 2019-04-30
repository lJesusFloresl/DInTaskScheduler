using System;
using System.Collections.Generic;
using System.Linq;

namespace DInTaskScheduler.Domain.ViewModels
{
    public class DailySummaryReportFilterViewModel
    {
        public int IdHeadQuarter { get; set; }
        public DateTime ReportDate { get; set; }
        public IEnumerable<string> Emails { get; set; }

        public DailySummaryReportFilterViewModel()
        {
            this.Emails = new List<string>();
        }

        public DailySummaryReportFilterViewModel(int idHeadQuarter, DateTime reportDate, params string[] emails)
        {
            this.IdHeadQuarter = idHeadQuarter;
            this.ReportDate = reportDate;
            this.Emails = emails.ToList();
        }
    }
}
