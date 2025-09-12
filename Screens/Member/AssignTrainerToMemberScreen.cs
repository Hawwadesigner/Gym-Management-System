using GYM_System.Exceptions;
using GYM_System.Helper;
using GYM_System.Models;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Member
{
    public static class AssignTrainerToMemberScreen
    {
        private static void ShowTrainers(IEnumerable<TrainerModel> trainers)
        {
            Console.Clear();
            Console.WriteLine("┌──┬───────────────────────┬──────────────────────┐");
            Console.WriteLine("│ID│ Trainer Name          │ Specialization       │");
            Console.WriteLine("├──┼───────────────────────┼──────────────────────┤");

            if (!trainers.Any())
            {
                Console.WriteLine("│           No Trainers found!                   │");
                Console.WriteLine("└──┴───────────────────────┴──────────────────────┘");
                return;
            }

            foreach (var trainer in trainers)
            {
                Console.WriteLine($"│{trainer.Id.ToString().PadLeft(2)}" +
                                  $"│{trainer.FullName.PadRight(23)}" +
                                  $"│{trainer.Specialization.Name.PadRight(22)}│");
            }
            Console.WriteLine("└──┴───────────────────────┴──────────────────────┘");
        }

        public static void Show(IEnumerable<TrainerModel> trainers, MemberService memberService)
        {
            ShowTrainers(trainers);

            var totalTrainers = trainers.Count();

            // Trainer Id
            Console.WriteLine("\n\n-> Select Trainer ID to assign with: ");
            var trainerId = InputHelper.ReadIntNumberBetween(1, totalTrainers);

            // Member Id
            var memberId = InputHelper.ReadInt("-> Enter Member ID: ");
            var member = memberService.GetById(memberId);
            if (member == null)
                throw new MemberNotFoundException();

            // Assigning
            member.TrainerId = trainerId;
            var trainer = trainers.FirstOrDefault(t => t.Id == trainerId);
            Console.WriteLine($"\n\nAssign with Tranier {trainer.FullName} successfully!");
        }
    }
}
