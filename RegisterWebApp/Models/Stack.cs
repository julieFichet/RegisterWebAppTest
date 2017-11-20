
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegisterWebApp.Models
{
    public class Stack
    {
        public int StackId { get; set; }
        public string StackText { get; set; }
        public ICollection<Developer> Developers { get; set; }
    }
}