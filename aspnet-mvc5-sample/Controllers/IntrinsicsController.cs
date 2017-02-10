using aspnet_mvc5_sample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnet_mvc5_sample.Controllers
{
    public class IntrinsicsController : Controller
    {
        private readonly ICacheService _cacheService;
        public IntrinsicsController() : this(new AspNetCacheService()) { }
        public IntrinsicsController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public ActionResult Index()
        {
            var data = _cacheService["foo"];
            if (data != null)
            {
                ViewBag.Message = data as string;
            }
            else
            {
                ViewBag.Message = "Empty";
            }

            return View();
        }
    }
}