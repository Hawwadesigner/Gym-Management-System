using GYM_System.Models;
using GYM_System.Services;
using System;

namespace GYM_System.Helper
{
    public static class SubscriptionInputHelper
    {
        public static SubscriptionModel FillSubscriptionData(SubscriptionModel subscription, bool IsUpdate = false, int memberId = 0)
        {
            if (IsUpdate == true)
            {
                Console.WriteLine("\n\n--------------------------------------------");
                Console.WriteLine("           CURRENT SUBSCRIPTION DATA        ");
                Console.WriteLine("\n--------------------------------------------");
                Console.WriteLine($"ID: {subscription.Id}" +
                                  $"\nStartDate: {subscription.DateSubscription.StartDate}" +
                                  $"\nEndDate: {subscription.DateSubscription.EndDate}" +
                                  $"\nServiceLevel: {subscription.ServiceLevel}" +
                                  $"\nPlanType: {subscription.PlanType}" +
                                  $"\nPrice: {subscription.Price}" +
                                  $"\nStatus: {subscription.Status}" +
                                  $"\nIsAutoRenew: {subscription.IsAutoRenew}");
                Console.WriteLine("\n--------------------------------------------");
            }

            // DateSubscription.StartDate Store as Temp 
            DateTime tempUpdatedStartDate = subscription.DateSubscription.StartDate;
            var startDate = InputHelper.ReadString($"-> Enter StartDate (yyyy/MM/dd){(IsUpdate ? $"(leave empty to keep '{subscription.DateSubscription.StartDate}')" : "")}: ");
            if (!string.IsNullOrWhiteSpace(startDate) && DateTime.TryParse(startDate, out DateTime updatedStartDate))
                tempUpdatedStartDate = updatedStartDate;

            // Service Level
            subscription.ServiceLevel = InputHelper.ReadEnumOrKeep("-> Select Service Level:\n[1] Standard\n[2] Premium\n[3] VIP", subscription.ServiceLevel, IsUpdate);

            // Plan Type
            subscription.PlanType = InputHelper.ReadEnumOrKeep("\n-> Select Plan Type:\n[1] Monthly\n[2] Yearly", subscription.PlanType, IsUpdate);

            // DateSubscription
            var endDate = InputHelper.CalculateEndDate(tempUpdatedStartDate, subscription.PlanType);
            var DateSubscription = new cDateSubscription()
            {
                StartDate = tempUpdatedStartDate,
                EndDate = endDate
            };

            // Price, Status
            subscription.Price = GymPricingService.GetPrice(subscription.ServiceLevel, subscription.PlanType);
            subscription.Status = endDate > DateTime.Today ? enStatus.Active : enStatus.Inactive;

            // IsAutoRenew 
            var isAutoRenewString = subscription.IsAutoRenew ? "YES" : "No";
            var autoRenewInput = InputHelper.ReadYesOrNo($"Do you want to Subscription Auto Renew ? (y/n) {(IsUpdate ? $"(leave empty to keep '{isAutoRenewString}" : "")}: ");
            if (autoRenewInput.HasValue)
                subscription.IsAutoRenew = autoRenewInput.Value;

            // Just for new subscription
            if (IsUpdate == false) 
                subscription.MemberId = memberId;

            return subscription;
        }

    }
}
