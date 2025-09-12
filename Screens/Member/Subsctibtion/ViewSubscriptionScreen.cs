using GYM_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYM_System.Screens.Member.Subscription
{
    public static class ViewSubscriptionsScreen
    {
        public static void Show(IEnumerable<SubscriptionModel> subscriptions)
        {
            Console.Clear();
            Console.WriteLine("┌──┬───────┬───────────────────┬────────────┬────────────┬────────────┬──────────┬────────┬─────────┬───────────┐");
            Console.WriteLine("│ID│ M.Id  │ Member Name       │ Start Date │ End Date   │ ServiceLvl │ PlanType │ Price  │ Status  │ AutoRenew │");
            Console.WriteLine("├──┼───────┼───────────────────┼────────────┼────────────┼────────────┼──────────┼────────┼─────────┼───────────┤");

            if (!subscriptions.Any())
            {
                Console.WriteLine("│                                   No Subscriptions found!                                                                                                    │");
                Console.WriteLine("└──┴───────┴───────────────────┴────────────┴────────────┴────────────┴──────────┴────────┴─────────┴───────────┘");
                return;
            }

            var sb = new StringBuilder(); 

            foreach (var sub in subscriptions)
            {
                sb.AppendLine($"│{sub.Id.ToString().PadLeft(2)}" +
                              $"│{sub.MemberId.ToString().PadLeft(7)}" +
                              $"│{sub.Member.FullName.PadRight(19).Substring(0, Math.Min(19, sub.Member.FullName.Length))}" +
                              $"│{sub.DateSubscription.StartDate:yyyy/MM/dd}" +
                              $"│{sub.DateSubscription.EndDate:yyyy/MM/dd}" +
                              $"│{sub.ServiceLevel.ToString().PadRight(12).Substring(0, 12)}" +
                              $"│{sub.PlanType.ToString().PadRight(10).Substring(0, 10)}" +
                              $"│{sub.Price.ToString("F2").PadLeft(8)}" +
                              $"│{sub.Status.ToString().PadRight(9).Substring(0, 9)}" +
                              $"│{(sub.IsAutoRenew ? "Yes" : "No").PadRight(11)}│");
            }
            Console.WriteLine("└──┴───────┴───────────────────┴────────────┴────────────┴────────────┴──────────┴────────┴─────────┴───────────┘");
        }
    }
}
