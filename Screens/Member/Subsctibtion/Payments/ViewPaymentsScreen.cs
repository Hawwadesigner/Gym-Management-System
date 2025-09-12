using GYM_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GYM_System.Screens.Member.Subscription.Payments
{
    public class ViewPaymentsScreen
    {
        public static void Show(IEnumerable<PaymentModel> payments)
        {
            Console.Clear();
            Console.WriteLine("┌──┬─────────┬───────────────────────┬────────────┬───────────┬────────────┐");
            Console.WriteLine("│ID│ Sub.ID  │ Member Name           │ Date       │ Type      │ Amount     │");
            Console.WriteLine("├──┼─────────┼───────────────────────┼────────────┼───────────┼────────────┤");

            if (!payments.Any())
            {
                Console.WriteLine("│                          No Payments found!                              │");
                Console.WriteLine("└──┴─────────┴───────────────────────┴────────────┴───────────┴────────────┘");
                return;
            }

            var sb = new StringBuilder();

            foreach (var payment in payments)
            {
                sb.AppendLine($"│{payment.Id.ToString().PadLeft(2)}" +
                              $"│{payment.SubscriptionId.ToString().PadLeft(7)}" +
                              $"│{payment.Subscription.Member.FullName.PadRight(23).Substring(0, Math.Min(23, payment.Subscription.Member.FullName.Length))}" +
                              $"│{payment.Date:yyyy/MM/dd}" +
                              $"│{payment.PaymentType.ToString().PadRight(9).Substring(0, 9)}" +
                              $"│{payment.Amount.ToString("F2").PadLeft(10)}│");
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine("└──┴─────────┴───────────────────────┴────────────┴───────────┴────────────┘");
        }
    }
}
