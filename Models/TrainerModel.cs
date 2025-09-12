using System;

namespace GYM_System.Models
{
    public class TrainerModel : PersonModel
    {
        public decimal Salary { get; set; }

        public SpecializationModel Specialization { get; set; } = new SpecializationModel();

        public ICollection<MemberModel> Members { get; set; }  = new List<MemberModel>();    
    }
}
