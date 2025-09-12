using System;

namespace GYM_System.Exceptions
{
    public class NotFoundException<T> : Exception
    {
        public NotFoundException()
            : base($"\n\n{typeof(T).Name} is not found!") { }
    }
}
