using GYM_System.Models;
using System;

namespace GYM_System.Helper
{
    public static class TrainerInputHelper
    {
        public static TrainerModel FillTrainerData(TrainerModel trainer, bool isUpdate = false)
        {
            if (isUpdate)
            {
                PersonDisplayHelper.ShowCurrentBasicData(trainer);// Show Basic Data

                Console.WriteLine($"\nSalary: {trainer.Salary}" +
                                  $"\nSpecialization: {trainer.Specialization.Name}");
                Console.WriteLine("\n----------------------------------------------------");
            }

            PersonInputHelper.FillBasicData(trainer); // Fill Basic Data

            // Salary
            var salary = InputHelper.ReadString($"-> Enter Salary{(isUpdate ? $"(leave empty to keep '{trainer.Salary}')" : "")}: ");
            if (!string.IsNullOrWhiteSpace(salary) && decimal.TryParse(salary, out decimal updatedSalary))
                trainer.Salary = updatedSalary;

            // Specialization
            var specialization = InputHelper.ReadString($"-> Enter Specialization{(isUpdate ? $"(leave empty to keep '{trainer.Specialization}')" : "")}: ");
            if (!string.IsNullOrWhiteSpace(specialization))
                trainer.Specialization.Name = specialization;

            return trainer;
        }

    }
}
