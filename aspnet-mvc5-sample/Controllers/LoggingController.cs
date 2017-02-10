using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace aspnet_mvc5_sample.Controllers
{
    public class LoggingController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        // GET: Logging
        public ActionResult Index()
        {
            logger.Trace("Index");

            var logDirectory = Server.MapPath("~/logs");
            string[] files = Directory.GetFiles(logDirectory, "*.log").Select(x => Path.GetFileName(x)).ToArray();
            ViewBag.Files = files;

            return View();
        }

        public ActionResult Display(string name)
        {
            if (name == null)
            {
                return RedirectToAction("Index", "Logging");
            }

            ViewBag.FileName = name;
            logger.Trace($"LogFile : {name}");
            var logDirectory = Server.MapPath("~/logs");

            var file = Path.Combine(logDirectory, name);
            using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding("Shift_JIS")))
            {
                ViewBag.Text = sr.ReadToEnd();
            }

            return View();
        }
    }
}