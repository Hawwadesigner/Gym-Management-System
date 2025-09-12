using GYM_System.Helper;
using GYM_System.Models;
using GYM_System.Screens.Member.Subscription;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Member.Subscription
{
    public static class SubscriptionsManagementMenu
    {
        public static void Show(SubscriptionChecker subscriptionChecker, SubscriptionService subscriptionService, MemberService memberService)
        {
            // Define handlers once 
            Action<SubscriptionModel> handlerAdded = (sub) =>
                NotificationHelper.Info($"Subscription for {sub.Member.FullName} added today", "Add");

            Action<SubscriptionModel> handlerEnded = (sub) =>
            {
                Console.Beep();
                NotificationHelper.Info($"Subscription for {sub.Member.FullName} ended today.\n" +
                $"Go to 'Update Subscription' to enable Auto Renew, otherwise ignore these message!", "End");
            };

            Action<SubscriptionModel> handlerAboutToExpire = (sub) =>
            {
                Console.Beep();
                NotificationHelper.Info($"Subscription for {sub.Member.FullName} will expire on {sub.DateSubscription.EndDate:yyyy/MM/dd}.\n" +
                $"Please renew soon to avoid interruption", "About To Expire");
            };

            // Define subscribers once
            subscriptionService.OnSubscriptionAdded += handlerAdded;
            subscriptionChecker.OnSubscriptionEnd += handlerEnded;
            subscriptionChecker.OnSubscriptionAboutToExpire += handlerAboutToExpire;

            // For Check Subscription End 
            subscriptionChecker.StartChecking();

            while (true) 
            {
                ConsoleUIHelper.ShowMenu("SUBSCRIPTION MENU", new List<string>
                {
                    "Add Subsription",
                    "View Subsriptions",
                    "Update Subsription",
                    "Delete Subsription",
                    "Main Menu"
                });

                var options = InputHelper.ReadIntNumberBetween(1, 5).ToString();

                switch(options)
                {
                    case "1": AddSubscriptionScreen.Show(subscriptionService, memberService); break;
                    case "2": ViewSubscriptionsScreen.Show(subscriptionService.GetAllLazy()); break;
                    case "3": UpdateSubscriptionScreen.Show(subscriptionService); break;
                    case "4": DeleteSubscriptionScreen.Show(subscriptionService); break;
                    case "5": 
                        subscriptionService.OnSubscriptionAdded -= handlerAdded;
                        subscriptionChecker.OnSubscriptionEnd -= handlerEnded;
                        subscriptionChecker.OnSubscriptionAboutToExpire -= handlerAboutToExpire;
                        return;
                }
                Console.WriteLine("\n\nPress any key to return to Subsription Menu Screen");
                Console.ReadKey();
            }
        }
    }
}
