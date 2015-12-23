using Kilimanjaro.Application;
using Kilimanjaro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kilimanjaro.UI.Web.Controllers
{
    public class OdontologistTypeController : Controller
    {
        private readonly ApplicationOdontologistType applicationOdontologistType;

        public OdontologistTypeController()
        {
            applicationOdontologistType = ConstructorApplication.ApplicationOdontologistTypeEF();
        }

        public ActionResult Index()
        {
            var odontologistTypeList = applicationOdontologistType.ListAll();
            return View(odontologistTypeList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OdontologistType odontologistType)
        {
            if (ModelState.IsValid)
            {
                applicationOdontologistType.Save(odontologistType);
                return RedirectToAction("Index");
            }

            return View(odontologistType);
        }

        public ActionResult Edit(string id)
        {
            var odontologistType = applicationOdontologistType.ListById(id);

            if (odontologistType == null)
                return HttpNotFound();

            return View(odontologistType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OdontologistType odontologistType)
        {
            if (ModelState.IsValid)
            {
                applicationOdontologistType.Save(odontologistType);
                return RedirectToAction("Index");
            }

            return View(odontologistType);
        }

        public ActionResult Details(string id)
        {
            var odontologistType = applicationOdontologistType.ListById(id);

            if (odontologistType == null)
                return HttpNotFound();

            return View(odontologistType);
        }

        public ActionResult Delete(string id)
        {
            var odontologistType = applicationOdontologistType.ListById(id);

            if (odontologistType == null)
                return HttpNotFound();

            return View(odontologistType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id)
        {
            var odontologistType = applicationOdontologistType.ListById(id);
            applicationOdontologistType.Delete(odontologistType);
            return RedirectToAction("Index");
        }
	}
}