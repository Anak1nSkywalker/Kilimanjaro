using Kilimanjaro.Application;
using Kilimanjaro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kilimanjaro.UI.Web.Controllers
{
    public class RecordController : Controller
    {
        private readonly ApplicationRecord applicationRecord;

        public RecordController()
        {
            applicationRecord = ConstructorApplication.ApplicationRecordEF();
        }

        public ActionResult Index()
        {
            var recordList = applicationRecord.ListAll();
            return View(recordList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Record record)
        {
            if (ModelState.IsValid)
            {
                applicationRecord.Save(record);
                return RedirectToAction("Index");
            }

            return View(record);
        }

        public ActionResult Edit(string id)
        {
            var record = applicationRecord.ListById(id);

            if (record == null)
                return HttpNotFound();

            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Record record)
        {
            if (ModelState.IsValid)
            {
                applicationRecord.Save(record);
                return RedirectToAction("Index");
            }

            return View(record);
        }

        public ActionResult Details(string id)
        {
            var record = applicationRecord.ListById(id);

            if (record == null)
                return HttpNotFound();

            return View(record);
        }

        public ActionResult Delete(string id)
        {
            var record = applicationRecord.ListById(id);

            if (record == null)
                return HttpNotFound();

            return View(record);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id)
        {
            var record = applicationRecord.ListById(id);
            applicationRecord.Delete(record);
            return RedirectToAction("Index");
        }
    }
}