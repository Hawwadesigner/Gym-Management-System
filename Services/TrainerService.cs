using GYM_System.Data;
using GYM_System.Helper;
using GYM_System.Models;
using System;

namespace GYM_System.Services
{
    public class TrainerService : BaseService<TrainerModel>
    {
        // Constructor
        public TrainerService(AppDbContext context) : base(context) { }
    }
}
