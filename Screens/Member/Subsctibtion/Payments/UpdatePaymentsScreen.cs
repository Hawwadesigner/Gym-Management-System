using GYM_System.Helper;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Member.Subscription.Payments
{
    public class UpdatePaymentsScreen
    {
        public void Show(PaymentsService paymentsService)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│          UPDATE PAYMENT           │");
            Console.WriteLine("└───────────────────────────────────┘");

            // Check 
            var result = CheckHelper.CheckAndConfirmAction(paymentsService, "Payment", "update", "Updating");
            if (result == null) return;

            var(_,payment) = result.Value; 

            // Fill Data
            PaymentInputHelper.FillPaymentData(payment, true);

            // Updating
            paymentsService.Update(payment);
            Console.WriteLine("\n\nPayment updated successfully!");
        }
    }
}
