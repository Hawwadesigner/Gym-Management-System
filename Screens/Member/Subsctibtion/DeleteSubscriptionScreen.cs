using GYM_System.Helper;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Member.Subscription
{
    public static class DeleteSubscriptionScreen
    {
        public static void Show(SubscriptionService subscriptionService)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│         DELETE SUBSCRIPTION       │");
            Console.WriteLine("└───────────────────────────────────┘");

            // Check
            var result = CheckHelper.CheckAndConfirmAction(subscriptionService, "Subscription", "delete", "Deletion");
            if (result == null) return;

            var (id, _) = result.Value;

            // Deleting
            subscriptionService.Delete(id);
            Console.WriteLine("Subscription deleted successfully!");        
        }
    }
}
