using CarsInventoryApp.Models;
using CI.Data.Models;
using log4net;
using System;
using System.Linq;
using System.Web.Mvc;
namespace CarsInventoryApp.Controllers
{
    public class AccountController : Controller
    {
        #region local variables and constructor
        private UnitOfWork _uow;
        private static readonly ILog log = LogManager.GetLogger(typeof(AccountController));

        public AccountController()
        {
            _uow = new UnitOfWork();
        }
        #endregion

        #region Action Methods
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserAccount user)
        {
            try
            {
                var result = _uow.UserRepository.Find(a => a.Email.Equals(user.Email) && a.Password.Equals(user.Password)).FirstOrDefault();
                if (result != null)
                {
                    Session["UserID"] = result.UserId.ToString();
                    Session["UserName"] = result.Name.ToString();
                    log.Info("User loggedin successfully");
                    return RedirectToAction("Index", "Cars");
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }
            return View(user);
        }

        [HttpGet]
        public PartialViewResult RegisterUser()
        {
            return PartialView("_RegisterUser", new UserAccount());
        }

        [HttpPost]
        public ActionResult RegisterUser(UserAccount user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CI.Data.Models.User objUser = new CI.Data.Models.User() { Email = user.Email, Password = user.Password, Name = user.Name };
                    _uow.UserRepository.Insert(objUser);
                    _uow.SaveChanges();
                    log.Info(string.Format("New User ({0}) registered successfully", user.Email));
                    return RedirectToAction("Login");
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }
            return View("_RegisterUser");
        }
        #endregion
    }
}
