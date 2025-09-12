using GYM_System.Data;
using GYM_System.Exceptions;
using GYM_System.Helper;
using GYM_System.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GYM_System.Services
{
    public class SubscriptionService : BaseService<SubscriptionModel>
    {
        public SubscriptionService(AppDbContext context) : base(context) { }

        public override void Delete(int id)
        {
            // Search & Include
            var subscription = _context.Subscriptions.Include(p => p.Payment).FirstOrDefault(s => s.Id == id);
            if (subscription == null) throw new SubscriptionNotFoundException();

            _context.Payments.RemoveRange(subscription.Payment);
            _context.Subscriptions.Remove(subscription);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine($"\n\nError: {ex.Message}"); }
        }

        // Event For Add
        public event Action<SubscriptionModel> OnSubscriptionAdded;
        public override void Add(SubscriptionModel subscription)
        {
            base.Add(subscription);
            OnSubscriptionAdded?.Invoke(subscription);
        }
    }
}
