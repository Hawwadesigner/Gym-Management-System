using GYM_System.Data;
using GYM_System.Models;
using System;

namespace GYM_System.Services
{
    public class AttendanceService :BaseService<AttendanceModel>
    {
        // Constructor
        public AttendanceService(AppDbContext context) :base (context) { }

        // Create Event
        public event Action<AttendanceModel> OnAttendanceRecorded;

        // Override Add & Fire Event
        public override void Add(AttendanceModel attendance)
        {
            base.Add(attendance);
            // Fire Event
            OnAttendanceRecorded?.Invoke(attendance);
        }
    }
}

