using Kilimanjaro.Application;
using Kilimanjaro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kilimanjaro.UI.Web.Controllers
{
    public class UserTypeController : Controller
    {
        private readonly ApplicationUserType applicationUserType;

        public UserTypeController()
        {
            applicationUserType = ConstructorApplication.ApplicationUserTypeEF();
        }

        public ActionResult Index()
        {
            var userTypeList = applicationUserType.ListAll();
            return View(userTypeList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserType userType)
        {
            if (ModelState.IsValid)
            {
                applicationUserType.Save(userType);
                return RedirectToAction("Index");
            }

            return View(userType);
        }

        public ActionResult Edit(string id)
        {
            var userType = applicationUserType.ListById(id);

            if (userType == null)
                return HttpNotFound();

            return View(userType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserType userType)
        {
            if (ModelState.IsValid)
            {
                applicationUserType.Save(userType);
                return RedirectToAction("Index");
            }

            return View(userType);
        }

        public ActionResult Details(string id)
        {
            var userType = applicationUserType.ListById(id);

            if (userType == null)
                return HttpNotFound();

            return View(userType);
        }

        public ActionResult Delete(string id)
        {
            var userType = applicationUserType.ListById(id);

            if (userType == null)
                return HttpNotFound();

            return View(userType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id)
        {
            var userType = applicationUserType.ListById(id);
            applicationUserType.Delete(userType);
            return RedirectToAction("Index");
        }
	}
}