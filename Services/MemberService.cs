using GYM_System.Data;
using GYM_System.Exceptions;
using GYM_System.Helper;
using GYM_System.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GYM_System.Services
{
    public class MemberService : BaseService<MemberModel>
    {
        // Constructor
        public MemberService(AppDbContext context) : base(context) { }
        public override void Delete(int id)
        {
            // Search & Include
            var member = _context.Members.Include(a => a.Attendances).Include(s => s.Subscriptions).FirstOrDefault(m => m.Id == id);
            if (member == null) throw new MemberNotFoundException();

            _context.Attendances.RemoveRange(member.Attendances);
            _context.Subscriptions.RemoveRange(member.Subscriptions);
            _context.Members.Remove(member);
            
            try
            {
                _context.SaveChanges();
            }
            catch(Exception ex) { Console.WriteLine($"\n\nError: {ex.Message}"); }
        }

        public bool IsMemberAttendanceBefore(MemberModel member)
            => _context.Set<AttendanceModel>().Any(d => d.MemberId == member.Id && d.Date.Date == DateTime.Today);
    }
}
