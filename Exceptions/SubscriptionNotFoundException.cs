using System;

namespace GYM_System.Exceptions
{
    public class SubscriptionNotFoundException : Exception
    {
        public SubscriptionNotFoundException() 
            : base($"\n\nSubscription is not found!") { }
    }
}
