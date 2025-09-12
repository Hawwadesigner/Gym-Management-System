using GYM_System.Helper;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Member
{
    public static class DeleteMemberScreen
    {
        public static void Show(MemberService memberService)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│           DELETE MEMBER           │");
            Console.WriteLine("└───────────────────────────────────┘");

            var result = CheckHelper.CheckAndConfirmAction(memberService, "Member", "delete", "Deletion");
            if (result == null) return;

            var (id, _) = result.Value;

            // deletion
            memberService.Delete(id);
            Console.WriteLine("\n\nMember deleted successfully!");
        }
    }
}
