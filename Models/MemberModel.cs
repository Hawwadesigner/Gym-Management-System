using System;

namespace GYM_System.Models
{
    public class MemberModel : PersonModel
    {
        public DateTime DateOfBirth { get; set; }
        public AddressModel Address { get; set; } = new AddressModel();

        // One Trainer -> Many Members
        public int TrainerId { get; set; }           
        public TrainerModel Trainer { get; set; }  

        // One Member -> Many Subscription, Attendence
        public ICollection<SubscriptionModel> Subscriptions { get; set; } = new List<SubscriptionModel>(); 
        public ICollection<AttendanceModel> Attendances { get; set; } = new List<AttendanceModel>();
    }
}
