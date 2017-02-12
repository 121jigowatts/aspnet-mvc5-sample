using aspnet_mvc5_mongodb.Models;
using aspnet_mvc5_mongodb.Services;
using aspnet_mvc5_mongodb.Services.Abstractions;
using aspnet_mvc5_mongodb.ViewModels;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace aspnet_mvc5_mongodb.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _service;

        #region Constructors
        public UsersController()
            : this(new UserService())
        {

        }
        public UsersController(IUserService service)
        {
            this._service = service;
        }
        #endregion


        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public ActionResult Search()
        {
            var model = new UserSearchViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Search(UserSearchViewModel inputModel)
        {
            var model = await _service.SearchAsync(inputModel.userSearchCondition);
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
                    await _service.InsertAsync(inputModel);
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

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _service.GetByIdAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User document)
        {
            if (document == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (await _service.UpdateAsync(document))
                    {
                        return RedirectToAction("Index");
                    }
                    ViewBag.ErrorMsg = "他のユーザにより更新されています。";
                    return View(document);
                }
                catch (Exception)
                {
                    ViewBag.ErrorMsg = "データ更新に失敗しました。";
                    return View(document);
                }
            }

            return View(document);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _service.GetByIdAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}