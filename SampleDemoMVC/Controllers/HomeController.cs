using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleDemoMVC.Models.Data;
using System.Collections;
using ExportCSV;

namespace SampleDemoMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {


            return View();
           

        }

        public  ActionResult TestExportToExcel()
        {

            return new customActionResult();
        }
    }

    public class customActionResult: ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            List<Customer> list = new List<Customer>
            {
                new Customer {
                    ID = 1,
                    Name ="Rishab",
                    ContactNumber ="576-634-2781",
                    Address = "877-7502 Venenatis Av.",
                    Country = "Sao Tome and Principe",
                    Email = "ante.blandit.viverra@Sed.co.uk"
                },
                new Customer {
                    ID = 2,
                    Name ="Shellie",
                    ContactNumber ="264-859-6466",
                    Address = "Ap #783-3534 Mollis St.",
                    Country = "Papua New Guinea",
                    Email = "porttitor@loremluctus.co.uk"
                },
                new Customer {
                    ID = 3,
                    Name ="Jameson",
                    ContactNumber ="832-637-6796",
                    Address = "254-9752 Feugiat Avenue",
                    Country = "Italy",
                    Email = "sed.dui@nonvestibulumnec.ca"
                },
                new Customer {
                    ID = 4,
                    Name ="Odette",
                    ContactNumber ="408-328-0174",
                    Address = "8765 Est. Road",
                    Country = "Antigua and Barbuda",
                    Email = "aliquam.eros@indolorFusce.com"
                },
                new Customer {
                    ID = 5,
                    Name ="Carlos",
                    ContactNumber ="572-378-2718",
                    Address = "8365 Sodales Rd.",
                    Country = "Guyana",
                    Email = "Nullam@bibendumfermentum.co.uk"
                },
            };

            ProcessDocument<Customer> objProcessDocument = new ProcessDocument<Customer>();
            string outputString = string.Empty;
            objProcessDocument.ExportToCsv(list, out outputString, context.HttpContext);

        }
    }
}