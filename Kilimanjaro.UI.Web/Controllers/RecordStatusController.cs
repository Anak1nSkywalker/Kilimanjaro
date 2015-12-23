using Kilimanjaro.Application;
using Kilimanjaro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kilimanjaro.UI.Web.Controllers
{
    public class RecordStatusController : Controller
    {
        private readonly ApplicationRecordStatus applicationRecordStatus;

        public RecordStatusController()
        {
            applicationRecordStatus = ConstructorApplication.ApplicationRecordStatusEF();
        }

        public ActionResult Index()
        {
            var recordStatusList = applicationRecordStatus.ListAll();
            return View(recordStatusList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecordStatus recordStatus)
        {
            if (ModelState.IsValid)
            {
                applicationRecordStatus.Save(recordStatus);
                return RedirectToAction("Index");
            }

            return View(recordStatus);
        }

        public ActionResult Edit(string id)
        {
            var recordStatus = applicationRecordStatus.ListById(id);

            if (recordStatus == null)
                return HttpNotFound();

            return View(recordStatus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RecordStatus recordStatus)
        {
            if (ModelState.IsValid)
            {
                applicationRecordStatus.Save(recordStatus);
                return RedirectToAction("Index");
            }

            return View(recordStatus);
        }

        public ActionResult Details(string id)
        {
            var recordStatus = applicationRecordStatus.ListById(id);

            if (recordStatus == null)
                return HttpNotFound();

            return View(recordStatus);
        }

        public ActionResult Delete(string id)
        {
            var recordStatus = applicationRecordStatus.ListById(id);

            if (recordStatus == null)
                return HttpNotFound();

            return View(recordStatus);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id)
        {
            var recordStatus = applicationRecordStatus.ListById(id);
            applicationRecordStatus.Delete(recordStatus);
            return RedirectToAction("Index");
        }
	}
}