using Newtonsoft.Json;
using RegisterWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RegisterWebApp.Controllers
{
    public class AllUsersController : Controller
    {
        string Baseurl = "http://localhost:62563";
        // GET: AllUsers
        public async Task<ActionResult> ListUsersView()
        {
            List<Developer> developers = new List<Developer>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("/api/Default");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var DevResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    developers = JsonConvert.DeserializeObject<List<Developer>>(DevResponse);

                }
                //returning the employee list to view  
                return View(developers);
            }
        }

        // GET: NewDev
        public ActionResult Create()
        { 
                return View();
            
        }

        public async Task<ActionResult> Edit(int DeveloperId)
        {
            Developer developer = new Developer();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(string.Format("/api/Default/", DeveloperId));

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var DevResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    developer = JsonConvert.DeserializeObject<Developer>(DevResponse);

                }
                //returning the employee list to view  
                return View(developer);
            }
        }

        public async Task<ActionResult> Delete(int DeveloperId)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.DeleteAsync(string.Format("/api/Default/", DeveloperId));

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var DevResponse = Res.Content.ReadAsStringAsync().Result;

                }
                return RedirectToAction("ListUsersView");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "LastName, FirstName,Address,Email,ContactPhone,DayBirth")]Developer developer)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.PostAsJsonAsync("/api/Default/", developer);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ListUsersView");

                    }                  
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(developer);
        }
    }
}