using GYM_System.Helper;
using GYM_System.Screens.Member;
using GYM_System.Services;
using System;

namespace GYM_System.Screens.Trainer
{
    public static class TrainersManagementMenu
    {
        public static void Show(TrainerService trainerService)
        {
            while (true)
            {
                ConsoleUIHelper.ShowMenu("TRAINER MENU", new List<string>
                {
                    "Add Trainer",
                    "View Trainers",
                    "Update Trainer",
                    "Main Menu"
                });

                var options = InputHelper.ReadIntNumberBetween(1, 4).ToString();

                switch (options)
                {
                    case "1": AddTrainerScreen.Show(trainerService); break;
                    case "2": ViewTrainersScreen.Show(trainerService.GetAllLazy()); break;
                    case "3": UpdateTrainerScreen.Show(trainerService); break;
                    case "4": return;
                }
                Console.WriteLine("\n\nPress any key to return to Trainer Menu screen");
                Console.ReadKey();
            }
        }
    }
}
