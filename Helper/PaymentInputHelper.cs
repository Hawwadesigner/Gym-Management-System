using GYM_System.Models;
using System;
using System.Text;

namespace GYM_System.Helper
{
    public static class PaymentInputHelper
    {
        public static PaymentModel FillPaymentData(PaymentModel payments, bool IsUpdate = false)
        {
            var sb = new StringBuilder();
            if(IsUpdate == true)
            {
                Console.WriteLine("\n\n---------------------------------------------");
                Console.WriteLine("            CURRENT PAYMENT DATA             ");
                Console.WriteLine("\n---------------------------------------------");
                sb.AppendLine($"ID: {payments.Id}" +
                              $"Date: {payments.Date:yyyy/MM/dd}" +
                              $"Payment Type: {payments.PaymentType}" +
                              $"Amount: {payments.Amount}");
                Console.WriteLine(sb.ToString());
                Console.WriteLine("\n---------------------------------------------");
            }

            // PayementType
            var paymentType = InputHelper.ReadEnumOrKeep("-> Select Payment Type:\n[1]Cash\n[2]Card", payments.PaymentType, IsUpdate);
            payments.PaymentType = paymentType;

            // Amount = Subscription.Price
            payments.Amount = payments.Subscription.Price;
            Console.WriteLine($"Amount (based on subscription): {payments.Amount:F2}");
            var attempdAmount = InputHelper.ReadInt("-> Enter Paid Amount: ");
            if(attempdAmount < payments.Amount)
            {
                Console.WriteLine($"\n\nYou attempd to pay {attempdAmount:F2}, the full amount is {payments.Amount:F2}, Remaining = {(payments.Amount - attempdAmount):F2}");
                Console.ReadLine();
            }
            
            // Date 
            payments.Date = DateTime.Now;

            return payments;
        }

    }
}
