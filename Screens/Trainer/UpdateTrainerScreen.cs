using GYM_System.Helper;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Trainer
{
    public static class UpdateTrainerScreen
    {
        public static void Show(TrainerService trainerService)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│           UPDATE TRAINER          │");
            Console.WriteLine("└───────────────────────────────────┘");

            var result = CheckHelper.CheckAndConfirmAction(trainerService, "Trainer", "update", "Updating");
            if (result == null) return;

            var (_, trainer) = result.Value;

            TrainerInputHelper.FillTrainerData(trainer, true);

            //updating
            trainerService.Update(trainer);
            Console.WriteLine("\n\nTrainer updated successfully!");
        }
    }
}
