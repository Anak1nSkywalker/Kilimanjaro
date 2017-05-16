using Kilimanjaro.Application;
using Kilimanjaro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kilimanjaro.UI.Web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationVehicle applicationVehicle;

        public VehicleController()
        {
            applicationVehicle = ConstructorApplication.ApplicationVehicleEF();
        }

        public ActionResult Index()
        {
            var vehicleList = applicationVehicle.ListAll();
            return View(vehicleList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                applicationVehicle.Save(vehicle);
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        public ActionResult Edit(string id)
        {
            var vehicle = applicationVehicle.ListById(id);

            if (vehicle == null)
                return HttpNotFound();

            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                applicationVehicle.Save(vehicle);
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        public ActionResult Details(string id)
        {
            var vehicle = applicationVehicle.ListById(id);

            if (vehicle == null)
                return HttpNotFound();

            return View(vehicle);
        }

        public ActionResult Delete(string id)
        {
            var vehicle = applicationVehicle.ListById(id);

            if (vehicle == null)
                return HttpNotFound();

            return View(vehicle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id)
        {
            var vehicle = applicationVehicle.ListById(id);
            applicationVehicle.Delete(vehicle);
            return RedirectToAction("Index");
        }
    }
}