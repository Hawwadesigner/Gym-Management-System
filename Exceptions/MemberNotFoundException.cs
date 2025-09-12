using System;

namespace GYM_System.Exceptions
{
    public class MemberNotFoundException : Exception
    {
        public MemberNotFoundException() 
            : base($"\n\nMember is not found!") { }
    }
}
