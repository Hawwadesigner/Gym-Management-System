using System;

namespace GYM_System.Exceptions
{
    public class TrainerNotFoundException : Exception
    {
        public TrainerNotFoundException() 
            : base($"\n\nTrainer is not found!") { }
    }
}
