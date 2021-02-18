using Microsoft.AspNetCore.Identity;
using RentACar_Domain_Layer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentACar_Domain_Layer.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        [Required]
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public List<Order> Orders { get; set;  }
    }
}
