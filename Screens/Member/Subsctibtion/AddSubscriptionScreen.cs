using GYM_System.Exceptions;
using GYM_System.Helper;
using GYM_System.Models;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Member.Subscription
{
    public static class AddSubscriptionScreen
    {
        public static int Show(SubscriptionService subscriptionService ,MemberService memberService)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│        ADD NEW SUBSCRIPTION       │");
            Console.WriteLine("└───────────────────────────────────┘");

            // Check of existence Any Member
            if (!memberService.GetAllLazy().Any())
            {
                Console.WriteLine("\n\nBefore that, Add Memebr First!");
                Console.WriteLine("Rediracting to Add Memebr Screen...");
                Console.ReadKey();
                AddMemberScreen.Show(memberService);
                return 0;
            }

            // Check Member for subscription
            var result = CheckHelper.CheckAndReturn(memberService, "Member");
            if (result == null) throw new MemberNotFoundException();

            var (memberId, _) = result.Value;

            // Fill Data
            var subscription = SubscriptionInputHelper.FillSubscriptionData(new SubscriptionModel(),false, memberId);
          
            // Adding
            subscriptionService.Add(subscription);
            Console.WriteLine($"\n\nSubscription added successfully!, SubscriptionID: {subscription.Id}, SubscriptionPrice: {subscription.Price} EGP");

            return subscription.Id;
        }
    }
}
