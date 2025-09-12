using Microsoft.EntityFrameworkCore;
using System;
public enum enServiceLevel { Standard = 1, Premium = 2, VIP = 3, UnKnown = 4 }
public enum enPlanType { Monthly = 1, Yearly = 2, UnKnown = 3 };
public enum enStatus { Active = 1, Inactive = 2, UnKnown = 3 };

namespace GYM_System.Models
{
    [Owned]
    public class cDateSubscription
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class SubscriptionModel
    {
        public int Id { get; set; }
        public cDateSubscription DateSubscription { get; set; } = new();
        public enServiceLevel ServiceLevel { get; set; }
        public enPlanType PlanType { get; set; }
        public decimal Price { get; set; }
        public enStatus Status { get; set; }
        public bool IsAutoRenew { get; set; }

        public int MemberId { get; set; }
        public MemberModel Member { get; set; }

        public PaymentModel Payment { get; set; }
    }
}
