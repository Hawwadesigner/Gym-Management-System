using GYM_System.Exceptions;
using GYM_System.Helper;
using GYM_System.Models;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Trainer
{
    public static class AddTrainerScreen
    {
        public static void Show(TrainerService trainerService)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────┐");
            Console.WriteLine("│           ADD NEW TRAINER         │");
            Console.WriteLine("└───────────────────────────────────┘");

            // Check
            var result = CheckHelper.CheckAndReturn(trainerService, "Trainer");
            if (result == null)  throw new TrainerNotFoundException(); 

            var (_, trainer) = result.Value;

            // Fill Data
            trainer = TrainerInputHelper.FillTrainerData(new TrainerModel());

            // Adding 
            trainerService.Add(trainer);
            Console.WriteLine($"\n\nTrainer added successfully!, Trainer ID: {trainer.Id}");
        }
    }
}
