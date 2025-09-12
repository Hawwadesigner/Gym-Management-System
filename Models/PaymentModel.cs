using System;
public enum enPaymentType { Cash = 1, Card = 2, UnKnown = 3 };

namespace GYM_System.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public enPaymentType PaymentType { get; set; }
        public decimal Amount { get; set; }

        public int SubscriptionId { get; set; }
        public SubscriptionModel Subscription { get; set; }
    }
}
