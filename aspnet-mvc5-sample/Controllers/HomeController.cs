using aspnet_mvc5_sample.Models;
using aspnet_mvc5_sample.Services.Abstractions;
using aspnet_mvc5_sample.Services.Home;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnet_mvc5_sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _service;
        public HomeController() : this(new HomeService())
        {
        }

        public HomeController(IHomeService service)
        {
            this._service = service;
        }

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

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(UserData inputModel)
        {
            var destinationFolder = Server.MapPath("~/Users");

            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            var postedFile = inputModel.Picture;
            if (postedFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(postedFile.FileName);
                var path = Path.Combine(destinationFolder, fileName);

                postedFile.SaveAs(path);
            }

            return RedirectToAction("FileIndex", "Home");
        }

        [HttpGet]
        public ActionResult FileIndex()
        {
            var destinationFolder = Server.MapPath("~/Users");
            string[] files = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories);
            ViewBag.files = files;

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }



        public JsonResult AutoComplete(String name)
        {
            var data = _service.GetPeopleByName(name);
            return Json(data);
        }


    }
}