using GuildCars.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Contact
    {
        public int ContactID { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Invalid Email Address.")]
        [RequiredIfEmpty("ContactPhone")]
        [Required]
        public string ContactEmail { get; set; }
        [Display(Name = "Phone")]
        [RequiredIfEmpty("ContactEmail")]
        [Phone(ErrorMessage = "Invalid Phone Nnumber.")]
        [Required]
        public string ContactPhone { get; set; }
        [Required]
        public string ContactMessage { get; set; }
    }
}
