using GYM_System.Exceptions;
using GYM_System.Helper;
using GYM_System.Models;
using GYM_System.Services;

namespace GYM_System.Screens.Member
{
    public static class AddMemberScreen
    {
        public static void Show(MemberService memberService)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│          ADD NEW MEMBER           │");
            Console.WriteLine("└───────────────────────────────────┘");

            // Check 
            var result = CheckHelper.CheckAndReturn(memberService, "Member");
            if (result == null) throw new MemberNotFoundException();

            var (_, member) = result.Value;

            // Fill Data
            member = MemberInputHelper.FillMemberData(new MemberModel());

            // Adding
            memberService.Add(member);
            Console.WriteLine($"\n\nMember added successfully!, Member ID : {member.Id}");
        }
    }
}

