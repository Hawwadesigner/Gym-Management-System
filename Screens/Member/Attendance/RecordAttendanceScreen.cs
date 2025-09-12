using GYM_System.Exceptions;
using GYM_System.Helper;
using GYM_System.Models;
using GYM_System.Services;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Security.Cryptography;
using System.Threading.Channels;

namespace GYM_System.Screens.Member.Attendance
{
    public static class RecordAttendanceScreen
    {
        public static void Show(MemberService memberService,AttendanceService attendanceService)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│         RECORD ATTENDANCE         │");
            Console.WriteLine("└───────────────────────────────────┘");

            var result = CheckHelper.CheckAndReturn(memberService,"Member");
            if (result == null) throw new MemberNotFoundException();

            var (memberId, member) = result.Value;

            if (memberService.IsMemberAttendanceBefore(member))
            {
                Console.WriteLine($"\n\nMember {member.FullName} recorded today already!");
                return;
            }

            var attendance = new AttendanceModel()
            {
                MemberId = memberId,
                Date = DateTime.Now
            };

            // Recording
            attendanceService.Add(attendance);
            Console.WriteLine($"\nAttendance of {member.FullName} recorded successfully!");
        }
    }
}
