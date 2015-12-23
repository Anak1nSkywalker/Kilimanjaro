using Client.FirstWebServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        FirstWebServiceClient client = new FirstWebServiceClient();

        public ActionResult Index()
        {
            ViewBag.Message = client.Message();

            int x = client.Add(5, 7);
            ViewBag.X = 5;
            ViewBag.Y = 7;
            ViewBag.Z = x;

            //ViewBag.User = client.TypeListAll();
            ViewBag.User = client.ListAll();
                   
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
