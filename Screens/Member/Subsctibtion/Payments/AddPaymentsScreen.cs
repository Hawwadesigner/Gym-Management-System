using GYM_System.Helper;
using System;
using GYM_System.Models;
using GYM_System.Services;

namespace GYM_System.Screens.Member.Subscription.Payments
{
    public class AddPaymentsScreen
    {
        public void Show(int subscriptionId, PaymentsService paymentsService)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│          ADD NEW PAYMENT          │");
            Console.WriteLine("└───────────────────────────────────┘");

            //Fill Data
            var payment = PaymentInputHelper.FillPaymentData(new PaymentModel());

            payment.SubscriptionId = subscriptionId;

            // Adding
            paymentsService.Add(payment);
            Console.WriteLine($"\n\nPayment added successfully!, Payment ID: {payment.Id}");
        }
    }
}
