using System;
using Microsoft.EntityFrameworkCore;
using GYM_System.Models;

namespace GYM_System.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<MemberModel> Members { get; set; }
        public DbSet<AttendanceModel> Attendances { get; set; }
        public DbSet<SubscriptionModel> Subscriptions { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<TrainerModel> Trainers { get; set; }
        public DbSet<SpecializationModel> Specializations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GYM_System;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberModel>().OwnsOne(m => m.Address);
            modelBuilder.Entity<SubscriptionModel>().OwnsOne(s => s.DateSubscription);

            modelBuilder.Entity<SubscriptionModel>().Property(s => s.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<PaymentModel>().Property(p => p.Amount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<TrainerModel>().Property(t => t.Salary).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SubscriptionModel>().HasOne(s => s.Payment).WithOne(p => p.Subscription).HasForeignKey<PaymentModel>(p => p.SubscriptionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
