using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIApplication.Models;

namespace WebAPIApplication.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DefaultConnection") { }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Stack> Stacks { get; set; }
        public DbSet<WebTechnologie> WebTechnologies { get; set; }
    }
}