using GYM_System.Data;
using GYM_System.Models;
using System;

namespace GYM_System.Services
{
    public class PaymentsService : BaseService<PaymentModel>
    {
        public PaymentsService(AppDbContext context) : base (context) { }
    }
}
