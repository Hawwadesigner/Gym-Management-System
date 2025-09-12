using GYM_System.Helper;
using GYM_System.Models;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Member.Subscription
{
    public static class UpdateSubscriptionScreen
    {
        public static void Show(SubscriptionService subscriptionService)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│         UPDATE SUBSCRIPTION       │");
            Console.WriteLine("└───────────────────────────────────┘");

            // Check
            var result = CheckHelper.CheckAndConfirmAction(subscriptionService, "Subscription", "update", "Updating");
            if (result == null) return;

            var (_, subscription) = result.Value;

            // Fill Data
            SubscriptionInputHelper.FillSubscriptionData(subscription, true);

            // Updating
            subscriptionService.Update(subscription);
            Console.WriteLine($"\n\nSubscription updated successfully!");
        }
    }
}


