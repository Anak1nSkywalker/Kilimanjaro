using Kilimanjaro.Application;
using Kilimanjaro.Domain;
using Kilimanjaro.Util.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kilimanjaro.UI.Web.Controllers
{
    public class AddressController : Controller
    {
        private readonly ApplicationAddress applicationAddress;

        public AddressController()
        {
            applicationAddress = ConstructorApplication.ApplicationAddressEF();
        }

        public ActionResult Index()
        {
            var addressList = applicationAddress.ListAll();
            return View(addressList);
        }

        public ActionResult Create()
        {
            ViewBag.dropDownBackyardType = Helpers.FillDropDownList<BackyardType>();
            ViewBag.dropDownFederativeUnit = Helpers.FillDropDownList<FederativeUnit>();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                applicationAddress.Save(address);
                return RedirectToAction("Index");
            }

            ViewBag.dropDownBackyardType = Helpers.FillDropDownList<BackyardType>(address.BackyardType.Id.ToString());
            ViewBag.dropDownFederativeUnit = Helpers.FillDropDownList<FederativeUnit>(address.FederativeUnit.Id.ToString());
            return View(address);
        }

        public ActionResult Edit(string id)
        {
            var address = applicationAddress.ListById(id);

            if (address == null)
                return HttpNotFound();

            ViewBag.dropDownBackyardType = Helpers.FillDropDownList<BackyardType>(address.BackyardType.Id.ToString());
            ViewBag.dropDownFederativeUnit = Helpers.FillDropDownList<FederativeUnit>(address.FederativeUnit.Id.ToString());
            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                applicationAddress.Save(address);
                return RedirectToAction("Index");
            }

            ViewBag.dropDownBackyardType = Helpers.FillDropDownList<BackyardType>(address.BackyardType.Id.ToString());
            ViewBag.dropDownFederativeUnit = Helpers.FillDropDownList<FederativeUnit>(address.FederativeUnit.Id.ToString());
            return View(address);
        }

        public ActionResult Details(string id)
        {
            var address = applicationAddress.ListById(id);

            if (address == null)
                return HttpNotFound();

            return View(address);
        }

        public ActionResult Delete(string id)
        {
            var address = applicationAddress.ListById(id);

            if (address == null)
                return HttpNotFound();

            return View(address);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id)
        {
            var address = applicationAddress.ListById(id);
            applicationAddress.Delete(address);
            return RedirectToAction("Index");
        }
	}
}