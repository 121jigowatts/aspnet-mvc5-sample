using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using aspnet_mvc5_sample.Data;
using aspnet_mvc5_sample.Models;
using aspnet_mvc5_sample.ViewModels.ToDo;
using aspnet_mvc5_sample.Services.Abstractions;
using aspnet_mvc5_sample.Services.ToDo;

namespace aspnet_mvc5_sample.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService _service;

        //private AppDbContext db = new AppDbContext();

        public ToDoController()
            :this(new ToDoService())
        {
        }

        public ToDoController(IToDoService service)
        {
            this._service = service;
        }

        // GET: ToDo
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            MvcApplication.CacheService["ToDoList"] = model;

            //return View(await db.Items.ToListAsync());
            return View(model);
        }

        // GET: ToDo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Item item = await db.Items.FindAsync(id);
            var model = await _service.GetByIdAsync((int)id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: ToDo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Title,Description,Deadline,Completed")] ItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(item);

                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: ToDo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = await _service.GetByIdAsync((int)id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: ToDo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Title,Description,Deadline,Completed")] ItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                await _service.EditAsync(item);
                //db.Entry(item).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: ToDo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Item item = await db.Items.FindAsync(id);
            var model = await _service.GetByIdAsync((int)id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: ToDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {

            await _service.DeleteAsync((int)id);

            //Item item = await db.Items.FindAsync(id);
            //db.Items.Remove(item);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
