using Kilimanjaro.Application;
using Kilimanjaro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kilimanjaro.UI.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationCustomer applicationCustomer;

        public CustomerController()
        {
            applicationCustomer = ConstructorApplication.ApplicationCustomerEF();
        }

        public ActionResult Index()
        {
            var customerList = applicationCustomer.ListAll();
            return View(customerList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                applicationCustomer.Save(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public ActionResult Edit(string id)
        {
            var customer = applicationCustomer.ListById(id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                applicationCustomer.Save(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public ActionResult Details(string id)
        {
            var customer = applicationCustomer.ListById(id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Delete(string id)
        {
            var customer = applicationCustomer.ListById(id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id)
        {
            var customer = applicationCustomer.ListById(id);
            applicationCustomer.Delete(customer);
            return RedirectToAction("Index");
        }
    }
}