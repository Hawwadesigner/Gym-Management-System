using GYM_System.Helper;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Member
{
    public static class MembersManagementMenu
    {
        public static void Show(MemberService memberService)
        {
            while(true)
            {
                ConsoleUIHelper.ShowMenu("MEMBER MENU", new List<string>
                {
                    "Add Member",
                    "View Members",
                    "AssignTrainerToMemberScreen",
                    "Update Member",
                    "Find Member (ID/Phone)",
                    "Delete Member",
                    "Main Menu"
                });

                var options = InputHelper.ReadIntNumberBetween(1, 5).ToString();

                switch(options)
                {
                   case "1": AddMemberScreen.Show(memberService); break;
                   case "2": ViewMemberScreen.Show(memberService.GetAllLazy());break;
                   case "3": AssignTrainerToMemberScreen.Show(, memberService);break;
                   case "4": UpdateMemberScreen.Show(memberService); break;
                   case "5": FindMemberScreen.Show(memberService);break;
                   case "6": DeleteMemberScreen.Show(memberService); break;
                   case "7": return;
                }
                Console.WriteLine("\n\nPress any key to return to Member Menu screen");
                Console.ReadKey();
            }
        }
    }
}
