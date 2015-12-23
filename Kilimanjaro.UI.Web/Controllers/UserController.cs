using Kilimanjaro.Application;
using Kilimanjaro.Domain;
using System.Web.Mvc;
using Kilimanjaro.Util.Library;

namespace Kilimanjaro.UI.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationUser applicationUser;

        public UserController()
        {
            applicationUser = ConstructorApplication.ApplicationUserEF();
        }

        public ActionResult Index()
        {
            var userList = applicationUser.ListAll();
            return View(userList);
        }

        public ActionResult Create()
        {
            ViewBag.dropDownUserType = Helpers.FillDropDownList<UserType>();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                applicationUser.Save(user);
                return RedirectToAction("Index");
            }

            ViewBag.dropDownUserType = Helpers.FillDropDownList<UserType>(user.UserType.Id.ToString());
            return View(user);
        }

        public ActionResult Edit(string id)
        {
            var user = applicationUser.ListById(id);

            if (user == null)
                return HttpNotFound();

            ViewBag.dropDownUserType = Helpers.FillDropDownList<UserType>(user.UserType.Id.ToString());
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                applicationUser.Save(user);
                return RedirectToAction("Index");
            }

            ViewBag.dropDownUserType = Helpers.FillDropDownList<UserType>(user.UserType.Id.ToString());
            return View(user);
        }

        public ActionResult Details(string id)
        {
            var user = applicationUser.ListById(id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        public ActionResult Delete(string id)
        {
            var user = applicationUser.ListById(id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id)
        {
            var user = applicationUser.ListById(id);
            applicationUser.Delete(user);
            return RedirectToAction("Index");
        }

        //public ActionResult UniqueLogin(string login)
        //{
        //    var user = applicationUser.GetByLogin(login);
        //    return login;
        //}

    }
}