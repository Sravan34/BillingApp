using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BillingApp.Models;
using Newtonsoft.Json;
using PagedList;

namespace BillingApp.Controllers
{
    public class HomeController : Controller
    {
        //Hosted web API REST Service base url
        string Baseurl = "https://test.e.net.kw/paykii/api/billercatelog";
        public async Task<ActionResult> Index(int? page)
        {
            //ViewBag.CurrentSort = sortOrder;
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            //if (searchString != null)
            //{
                //page = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            //ViewBag.CurrentFilter = searchString;

            //var students = from s in db.Students
            //               select s;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    students = students.Where(s => s.LastName.Contains(searchString)
            //                           || s.FirstMidName.Contains(searchString));
            //}
            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        students = students.OrderByDescending(s => s.LastName);
            //        break;
            //    case "Date":
            //        students = students.OrderBy(s => s.EnrollmentDate);
            //        break;
            //    case "date_desc":
            //        students = students.OrderByDescending(s => s.EnrollmentDate);
            //        break;
            //    default:  // Name ascending 
            //        students = students.OrderBy(s => s.LastName);
            //        break;
            //}


            IPagedList<BillerCatalog> pagedBilling = null;
        List<BillerCatalog> BillingInfo = new List<BillerCatalog>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync(Baseurl);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var BillingResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    BillingInfo = JsonConvert.DeserializeObject<List<BillerCatalog>>(BillingResponse);
                }
                //returning the employee list to view
                int pageSize = 6;
                int pageNumber = (page ?? 1);
                pagedBilling = BillingInfo.ToPagedList(pageNumber, pageSize);
                return View(pagedBilling);
                //return View(BillingInfo);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public List<BillerCatelog> GetBillerCatalogs()
        //{
            
        //}
    }
}