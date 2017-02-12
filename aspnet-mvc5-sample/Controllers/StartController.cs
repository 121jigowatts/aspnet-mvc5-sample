using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnet_mvc5_sample.Controllers
{
    public class StartController : Controller
    {
        // GET: Start
        public ActionResult Index()
        {
            var startTime = MvcApplication.CacheService["StartTime"];
            if (startTime != null)
            {
                ViewBag.StartTime = ((DateTime)startTime).ToString("yyyy/MM/dd HH:mm:ss.fff");
            }

            return View();
        }
    }
}