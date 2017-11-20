using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAPIApplication.Models
{
    public class Developer
    {
        [Key]
        public int DeveloperId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "ContactPhone is not valid")]
        public string ContactPhone { get; set; }
        [Required]
        public string DayBirth { get; set; }

        public ICollection<WebTechnologie> WebTechnologies { get; set; }

        [Range(0,50)]
        public int? YearsOfExperience { get; set; }
        public ICollection<Stack> Stacks { get; set; }
        public string Comments { get; set; }
    }

   


}