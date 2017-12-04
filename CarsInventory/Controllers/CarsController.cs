using CarsInventoryApp.Models;
using CI.Data.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarsInventoryApp.Controllers
{
    public class CarsController : Controller
    {
        #region local variables and constructor
        private UnitOfWork _uow;
        private static readonly ILog log = LogManager.GetLogger(typeof(AccountController));

        public CarsController()
        {
            _uow = new UnitOfWork();
        }
        #endregion

        #region Action methods
        [HttpGet]
        public ActionResult Index()
        {
            CarSearch model = new CarSearch();
            try
            {
                model = getCars();
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CarSearch searchCriteria)
        {
            CarSearch model = new CarSearch();
            try
            {
                model = getCars();
                model.Cars = model.Cars.Where(c => (c.Brand == searchCriteria.Brand || c.Model == searchCriteria.Model)).ToList();
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }
            return View(model);
        }

        public ActionResult SearchCars(CarSearch searchCriteria, string userAction)
        {
            CarSearch model = new CarSearch();
            try
            {
                if (userAction.Equals("logout"))
                {
                    Session.Abandon();
                    Session.Clear();
                    log.Info("User logged out successfully!");
                    return RedirectToAction("Login", "Account");
                }
                else if (userAction.Equals("search"))
                {
                    model = getCars();
                    if (!string.IsNullOrEmpty(searchCriteria.Brand) && !string.IsNullOrEmpty(searchCriteria.Model))
                    {
                        model.Cars = model.Cars.Where(c => (c.Brand == searchCriteria.Brand && c.Model == searchCriteria.Model)).ToList();
                    }
                    else
                    {
                        model.Cars = model.Cars.Where(c => (c.Brand == searchCriteria.Brand || c.Model == searchCriteria.Model)).ToList();
                    }
                }
                else
                {
                    model = getCars();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }
            return PartialView("_CarsList", model);
        }

        [HttpGet]
        public PartialViewResult AddCar()
        {
            return PartialView("_AddCar", new CarInventory());
        }

        [HttpPost]
        public ActionResult AddCar(CarInventory car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = Convert.ToInt32(Session["UserID"]);
                    Car objCar = new Car() { Brand = car.Brand, Model = car.Model, Year = car.Year, Price = car.Price, New = car.New, UserId = userId };
                    _uow.CarRepository.Insert(objCar);
                    _uow.SaveChanges();
                    log.Info("New car added successfully!");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }
            return View("_AddCar");
        }

        [HttpGet]
        public PartialViewResult EditCar(int id)
        {
            CarInventory car = new CarInventory();
            try
            {
                var objCar = _uow.CarRepository.Find(a => a.Id.Equals(id)).FirstOrDefault();
                if (objCar != null)
                {
                    car = new CarInventory() { Id = objCar.Id, Brand = objCar.Brand, Model = objCar.Model, Year = objCar.Year, Price = objCar.Price, New = objCar.New };
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }

            return PartialView("_EditCar", car);
        }

        [HttpPost]
        public ActionResult EditCar(CarInventory car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var objCar = _uow.CarRepository.Find(a => a.Id.Equals(car.Id)).FirstOrDefault();
                    if (objCar != null)
                    {
                        objCar.Brand = car.Brand;
                        objCar.Model = car.Model;
                        objCar.Year = car.Year;
                        objCar.Price = car.Price;
                        objCar.New = car.New;
                        _uow.CarRepository.Update(objCar);
                        _uow.SaveChanges();
                        log.Info(string.Format("Car (Id:{0}) added successfully!", objCar.Id));
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }
            return View("_EditCar");
        }
        #endregion

        #region Private methods
        private CarSearch getCars()
        {            
            List<Cars> cars = new List<Cars>();
            try
            {
                if (Session["UserID"] != null)
                {
                    int userId = Convert.ToInt32(Session["UserID"]);
                    var carsList = _uow.CarRepository.All().Where(c=>c.UserId==userId);
                    foreach (var c in carsList.ToList())
                    {
                        cars.Add(new Cars() { Id = c.Id, Brand = c.Brand, Model = c.Model, Year = c.Year, Price = c.Price, New = c.New });
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }
            return new CarSearch { Cars = cars };
        }        
        #endregion
    }
}
