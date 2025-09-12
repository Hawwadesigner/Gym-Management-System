using GYM_System.Helper;
using GYM_System.Models;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Member
{
    public static class UpdateMemberScreen
    {
        public static void Show(MemberService memberService)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│           UPDATE MEMBER           │");
            Console.WriteLine("└───────────────────────────────────┘");

            // Check
            var result = CheckHelper.CheckAndConfirmAction(memberService, "Member", "update", "Updating");
            if (result == null) return;

            var (_, member) = result.Value; 

            // Fill Data
            MemberInputHelper.FillMemberData(member, true);

            // Updating
            memberService.Update(member);
            Console.WriteLine($"\n\nMember updated successfully!");
        }
    }
}
