using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3_MVCApplication.Controllers
{
    public class HomeController : Controller //always inherits the controller class
        //this  is the same with all controllers and they need to be within the controller folder
    {
        //every page is an action that returns the respective view within the controller
        //for every action-page there is a respective cshtml in the views folder
        //what is rendered however in the front page of the end user is within the shared folder where there is a common _layout
        public ActionResult Index()
        {
            return View();
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
    }
}