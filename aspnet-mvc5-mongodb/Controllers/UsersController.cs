using aspnet_mvc5_mongodb.Models;
using aspnet_mvc5_mongodb.Repositories;
using aspnet_mvc5_mongodb.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace aspnet_mvc5_mongodb.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _repository;
        public UsersController()
            : this(new UserRepository())
        {

        }
        public UsersController(IUserRepository repository)
        {
            this._repository = repository;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _repository.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User inputModel)
        {
            if (inputModel == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.InsertAsync(inputModel);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewBag.ErrorMsg = "データ登録に失敗しました。";
                    return View(inputModel);
                }
            }
            return View(inputModel);
        }
    }
}