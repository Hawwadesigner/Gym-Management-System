using GYM_System.Models;
using System;
using System.Text;

namespace GYM_System.Screens.Trainer
{
    public static class ViewTrainersScreen
    {
        public static void Show(IEnumerable<TrainerModel> trainers)
        {
            Console.Clear();
            Console.WriteLine("┌──┬──────────────────┬────────────────┬───────────────────────┬──────────┬──────────────────┐");
            Console.WriteLine("│ID│ Full Name        │ Phone          │ Email                 │ Salary   │ Specialization   │");
            Console.WriteLine("├──┼──────────────────┼────────────────┼───────────────────────┼──────────┼──────────────────┤");

            if (!trainers.Any())
            {
                Console.WriteLine("│                                No Trainers found!                               │");
                Console.WriteLine("└──┴──────────────────┴────────────────┴───────────────────────┴──────────┴──────────────────┘");
                return;
            }

            var sb = new StringBuilder();

            foreach (var trainer in trainers)
            {
                sb.AppendLine($"│{trainer.Id.ToString().PadLeft(2)}" +
                              $"│{trainer.FullName.PadRight(18)}" +
                              $"│{trainer.Phone.PadRight(16)}" +
                              $"│{trainer.Email.PadRight(23)}" +
                              $"│{trainer.Salary.ToString().PadLeft(8)}" +
                              $"│{trainer.Specialization.Name.PadRight(18)}│");
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine("└──┴──────────────────┴────────────────┴───────────────────────┴──────────┴──────────────────┘");
        }
    }
}
