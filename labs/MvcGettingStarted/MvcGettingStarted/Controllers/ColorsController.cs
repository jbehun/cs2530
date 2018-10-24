using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGettingStarted.Controllers
{
    public class ColorsController : Controller
    {
        //
        // GET: /Colors/

        public ActionResult ViewColors()
        {
            return View();
        }

        //
        // GET: /Colors/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Colors/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Colors/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Colors/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Colors/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Colors/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Colors/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
