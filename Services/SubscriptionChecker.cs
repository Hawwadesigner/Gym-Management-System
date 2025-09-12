using GYM_System.Data;
using GYM_System.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GYM_System.Services
{
    public class SubscriptionChecker
    {
        private Timer? _timer;
        private int _isRunning = 0; // 0 = Not running, 1 = running

        // Event For End
        public event Action<SubscriptionModel>? OnSubscriptionEnd;
        // Event For AboutToExpire
        public event Action<SubscriptionModel>? OnSubscriptionAboutToExpire;

        // Start Timer
        public void StartChecking() =>
        _timer = new Timer(_ => CheckSubscriptionEndSafe(), null, TimeSpan.Zero, TimeSpan.FromMinutes(60));
     
        // Method For the Logic
        private void CheckSubscriptionEndSafe()
        {
            if (Interlocked.Exchange(ref _isRunning, 1) == 1) return; // Avoid overlap

            try
            {
                using var db = new AppDbContext();

                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);

                // For End Event
                var endingToday = db.Subscriptions.Include(s => s.Member).Where(s => s.DateSubscription.EndDate.Date >= today && s.DateSubscription.EndDate.Date < tomorrow).AsNoTracking().ToList();
                foreach (var sub in endingToday)
                {
                    try
                    {
                        OnSubscriptionEnd?.Invoke(sub);
                    }
                    catch (Exception ex) { Console.WriteLine($"\n\nSubscriber Error: (End) {ex.Message}"); }
                }

                // For AboutToExpire
                var aboutToExpire = db.Subscriptions.Include(s => s.Member).Where(s => s.DateSubscription.EndDate.Date > today && s.DateSubscription.EndDate.Date <= today.AddDays(7)).AsNoTracking().ToList();
                foreach (var sub in aboutToExpire)
                {
                    try
                    {
                        OnSubscriptionAboutToExpire?.Invoke(sub);
                    }
                    catch (Exception ex) { Console.WriteLine($"\n\nSubscriber Error: (AboutToExpire) {ex.Message}"); }
                }
            }
            catch (Exception ex) { Console.WriteLine($"\n\nError Checking subscriptions: {ex.Message}"); }
            finally { Interlocked.Exchange(ref _isRunning, 0); }
        }
       
        // Stop Timer -> Called when close app
        public void StopChecking()
        {
            _timer?.Dispose();
            _timer = null;
        }
    }
}
