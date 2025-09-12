using System;

namespace GYM_System.Services
{
    public static class GymPricingService
    {
        private static readonly Dictionary<(enServiceLevel,enPlanType),int> Plans = new()
        {
           { (enServiceLevel.Standard, enPlanType.Monthly),  800 },
           { (enServiceLevel.Standard, enPlanType.Yearly),  8000 },
           { (enServiceLevel.Premium,  enPlanType.Monthly), 1200 },
           { (enServiceLevel.Premium,  enPlanType.Yearly), 12000 },
           { (enServiceLevel.VIP,      enPlanType.Monthly), 2000 },
           { (enServiceLevel.VIP,      enPlanType.Yearly), 20000 },
        };

        public static int GetPrice(enServiceLevel serviceLevel, enPlanType planType)
        {
            if (Plans.TryGetValue((serviceLevel, planType), out var price))
                return price;

            throw new KeyNotFoundException($"\n\nNo pricing found for {serviceLevel} - {planType}");
        }        
    }
}
