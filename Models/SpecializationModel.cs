using System;


namespace GYM_System.Models
{
    public class SpecializationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TrainerId { get; set; }
        public TrainerModel Trainer { get; set; }
    }
}
