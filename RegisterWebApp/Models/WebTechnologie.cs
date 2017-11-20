using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegisterWebApp.Models
{
    public class WebTechnologie
    {
        public int WebTechnologieId { get; set; }
        public string WebTechnologieText { get; set; }
        public ICollection<Developer> Developers { get; set; }
    }
}