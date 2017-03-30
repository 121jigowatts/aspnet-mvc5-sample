using aspnet_mvc5_sample.Services.Abstractions;
using aspnet_mvc5_sample.Services.Report;
using aspnet_mvc5_sample.ViewModels.ToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnet_mvc5_sample.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _service;
        public ReportController() : this(new ReportService())
        {
        }

        public ReportController(IReportService service)
        {
            _service = service;
        }

        public ActionResult Todo()
        {
            ToDoListViewModel model;
            if (MvcApplication.CacheService["ToDoList"] == null)
            {
                model = _service.GetAll();
            }
            else
            {
                model = MvcApplication.CacheService["ToDoList"] as ToDoListViewModel;
            }
            return View(model);
        }

        public ActionResult TodoReport()
        {
            var pdfData = CreatePDF("Todo", "Report", null);

            return File(pdfData, "application/pdf", "TodoReport.pdf");
        }

        private byte[] CreatePDF(string actionName, string controllerName, object routeValues = null)
        {
            var helper = new UrlHelper(ControllerContext.RequestContext);
            var indexUrl = helper.Action(actionName, controllerName, routeValues, Request.Url.Scheme);

            return _service.Create(indexUrl);
        }
    }
}