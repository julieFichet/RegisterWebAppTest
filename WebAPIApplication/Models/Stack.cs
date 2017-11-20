using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class Stack
    {
        [Key]
        public int StackId { get; set; }
        public string StackText { get; set; }
        public ICollection<Developer> Developers { get; set; }
    }
}