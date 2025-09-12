using GYM_System.Data;
using GYM_System.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GYM_System.Services
{
    public class ReportService
    {
        private readonly AppDbContext _context;
        public ReportService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SubscriptionModel> GetMembersWhoseSubscriptionsAreAboutToExpire() => _context.Set<SubscriptionModel>().Include(s => s.Member).Where(s => s.DateSubscription.EndDate.Date > DateTime.Today && s.DateSubscription.EndDate.Date <= DateTime.Today.AddDays(7)).AsNoTracking().ToList();

        public IEnumerable<TrainerModel> GetMembersListbyTrainer() => _context.Set<TrainerModel>().Include(t => t.Members).AsNoTracking().ToList();

        public Dictionary<string,decimal> GetRevenueInSpecificMonth(int month)
        {
            // all subscriptions
            var subscriptions = _context.Set<SubscriptionModel>().Where(s => s.DateSubscription.StartDate.Date.Month == month);

            decimal sumStandard = subscriptions.Where(s=>s.ServiceLevel == enServiceLevel.Standard).Sum(s=> s.Price);
            decimal sumPremium = subscriptions.Where(s => s.ServiceLevel == enServiceLevel.Premium).Sum(s => s.Price);
            decimal sumVIP = subscriptions.Where(s=>s.ServiceLevel == enServiceLevel.VIP).Sum(s=> s.Price);

            decimal total = sumStandard + sumPremium + sumVIP;

            return new Dictionary<string, decimal>
            {
                { "Standard", sumStandard },
                { "Premium" , sumPremium},
                { "VIP", sumVIP},
                { "Total", total}
            };
        }

        public IEnumerable<AttendanceReportModel> GetMostActiveAttendanceCommittedMembers() => _context.Set<AttendanceModel>().Include(a => a.Member).AsNoTracking().GroupBy(a => a.Member).Select(g => new AttendanceReportModel{ MemberName = g.Key.FullName, AttendanceCount = g.Count() }).OrderByDescending(a => a.AttendanceCount).ToList();
    }
}
