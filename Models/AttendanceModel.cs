using System;

namespace GYM_System.Models
{
    public class AttendanceModel
    {
       public int Id { get; set; }
       public DateTime Date { get; set; }

       public int MemberId { get; set; }
       public MemberModel Member { get; set; } 
    }
}
