using Kilimanjaro.Application;
using Kilimanjaro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kilimanjaro.UI.Web.Controllers
{
    public class OdontologistController : Controller
    {
        private readonly ApplicationOdontologist applicationOdontologist;

        public OdontologistController()
        {
            applicationOdontologist = ConstructorApplication.ApplicationOdontologistEF();
        }

        public ActionResult Index()
        {
            var odontologistList = applicationOdontologist.ListAll();
            return View(odontologistList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Odontologist odontologist)
        {
            if (ModelState.IsValid)
            {
                applicationOdontologist.Save(odontologist);
                return RedirectToAction("Index");
            }

            return View(odontologist);
        }

        public ActionResult Edit(string id)
        {
            var odontologist = applicationOdontologist.ListById(id);

            if (odontologist == null)
                return HttpNotFound();

            return View(odontologist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Odontologist odontologist)
        {
            if (ModelState.IsValid)
            {
                applicationOdontologist.Save(odontologist);
                return RedirectToAction("Index");
            }

            return View(odontologist);
        }

        public ActionResult Details(string id)
        {
            var odontologist = applicationOdontologist.ListById(id);

            if (odontologist == null)
                return HttpNotFound();

            return View(odontologist);
        }

        public ActionResult Delete(string id)
        {
            var record = applicationOdontologist.ListById(id);

            if (record == null)
                return HttpNotFound();

            return View(record);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id)
        {
            var odontologist = applicationOdontologist.ListById(id);
            applicationOdontologist.Delete(odontologist);
            return RedirectToAction("Index");
        }
	}
}