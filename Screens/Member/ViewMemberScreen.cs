using GYM_System.Models;
using GYM_System.Services;
using System;
using System.Text;

namespace GYM_System.Screens.Member
{
    public static class ViewMemberScreen
    {
        public static void Show(IEnumerable<MemberModel> members)
        {
            Console.Clear();
            Console.WriteLine("┌──┬──────────────────┬────────────────┬───────────────────────┬───┬──────────┬─────────────┬───────────────────┬───┐");
            Console.WriteLine("│ID│ Full Name        │ Phone          │ Email                 │Age│ City     │ Region      │ Street            │Bld│");
            Console.WriteLine("├──┼──────────────────┼────────────────┼───────────────────────┼───┼──────────┼─────────────┼───────────────────┼───┤");

            if (!members.Any())
            {
                Console.WriteLine("│                                             No Members found!                                                     │");
                Console.WriteLine("└──┴──────────────────┴────────────────┴───────────────────────┴───┴──────────┴─────────────┴───────────────────┴───┘");
                return;
            }

            var sb = new StringBuilder();

            foreach (var member in members)
            {
                // Calculate Age
                var today = DateTime.Today;
                var age = today.Year - member.DateOfBirth.Year;
                if (member.DateOfBirth.Date > today.AddYears(-age)) age--;

                sb.AppendLine($"│{member.Id.ToString().PadLeft(2)}" +
                              $"│{member.FullName.PadRight(18)}" +
                              $"│{member.Phone.PadRight(16)}" +
                              $"│{member.Email.PadRight(23)}" +
                              $"│{age.ToString().PadLeft(3)}" +
                              $"│{member.Address.City.PadRight(10)}" +
                              $"│{member.Address.Region.PadRight(13)}" +
                              $"│{member.Address.Street.PadRight(19)}" +
                              $"│{member.Address.Building.ToString().PadLeft(3)}│");
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine("└──┴──────────────────┴────────────────┴───────────────────────┴───┴──────────┴─────────────┴───────────────────┴───┘");
        }
    }
}
