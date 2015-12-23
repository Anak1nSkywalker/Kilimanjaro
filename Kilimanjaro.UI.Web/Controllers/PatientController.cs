using Kilimanjaro.Application;
using Kilimanjaro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kilimanjaro.UI.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationPatient applicationPatient;

        public PatientController()
        {
            applicationPatient = ConstructorApplication.ApplicationPatientEF();
        }

        public ActionResult Index()
        {
            var patientList = applicationPatient.ListAll();
            return View(patientList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                applicationPatient.Save(patient);
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        public ActionResult Edit(string id)
        {
            var patient = applicationPatient.ListById(id);

            if (patient == null)
                return HttpNotFound();

            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                applicationPatient.Save(patient);
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        public ActionResult Details(string id)
        {
            var patient = applicationPatient.ListById(id);

            if (patient == null)
                return HttpNotFound();

            return View(patient);
        }

        public ActionResult Delete(string id)
        {
            var patient = applicationPatient.ListById(id);

            if (patient == null)
                return HttpNotFound();

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id)
        {
            var patient = applicationPatient.ListById(id);
            applicationPatient.Delete(patient);
            return RedirectToAction("Index");
        }
    }
}