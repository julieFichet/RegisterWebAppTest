using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIApplication.Models;

namespace WebAPIApplication.Context
{
    public class InitializeDataBase : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            base.Seed(context);
            var stacks = new List<Stack>
            {
                new Stack{ StackText="FrontEnd"},
                new Stack{ StackText="BackEnd"},
                new Stack{ StackText="FullStack"},
                new Stack{ StackText="DevOps"},
            };
            var webTechnologies = new List<WebTechnologie>
            {
                new WebTechnologie{ WebTechnologieText="PHP"},
                new WebTechnologie{ WebTechnologieText=".Net"},
                new WebTechnologie{ WebTechnologieText="Java"},
                new WebTechnologie{ WebTechnologieText="Other"},
                new WebTechnologie{ WebTechnologieText="etc"},
            };
            var Developer = new Developer
            {
                FirstName = "Dev1",
                LastName = "Dev1",
                Address = "Place D'armes",
                ContactPhone = "5559999999",
                Email = "julie.fichet@amaris.com",
                DayBirth=DateTime.Now.ToString(),
                YearsOfExperience = 5,
                Comments= "Test de developper",

            };
            context.Stacks.AddRange(stacks);
            context.WebTechnologies.AddRange(webTechnologies);
            context.Developers.Add(Developer);
            context.SaveChanges();
        }
    }
}