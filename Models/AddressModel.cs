using System;
using Microsoft.EntityFrameworkCore;

namespace GYM_System.Models
{
    [Owned]
    public class AddressModel
    {
        public string City { get; set; }    
        public string Region { get; set; }
        public string Street { get; set; }
        public int Building { get; set; }
    }
}
