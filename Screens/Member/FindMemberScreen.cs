using GYM_System.Helper;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Member
{
    public static class FindMemberScreen
    {
        public static void Show(MemberService memberService)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│           Find MEMBER             │");
            Console.WriteLine("└───────────────────────────────────┘");
            Console.WriteLine("\n\nFind Member by [1]Id or [2]Phone");
            var option = InputHelper.ReadIntNumberBetween(1, 2).ToString();
            
            var result = option == "1" ? CheckHelper.CheckAndReturn(memberService, "Member")
                                     : CheckHelper.CheckAndReturnByPhone(memberService, "Member");

            if (result == null) return;

            // Show
            var (_, member) = result.Value;
            MemberInputHelper.ShowMemberData(member);
            
        }
    }
}
