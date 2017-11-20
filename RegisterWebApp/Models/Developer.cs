using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterWebApp.Models
{
    public class Developer
    {
        public int DeveloperId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactPhone { get; set; }
        public DateTime DayBirth { get; set; }
        public List<WebTechnologie> WebTechnologies { get; set; }
        public int YearsOfExperience { get; set; }
        public List<Stack> Stacks { get; set; }
        public string Comments { get; set; }
    }
}