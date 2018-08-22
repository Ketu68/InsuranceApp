using InsuranceApp1.Models;
using InsuranceApp1.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceApp1.Controllers
{
    public class HomeController : Controller
    {
        public int RunningTotal = 50;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string emailAddress, int age, int carYear, string carMake, string carModel, string dui, int speedingTickets, string coverage)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))  {
                return View("~/Views/Shared/Error1.cshtml");
            }
            if (string.IsNullOrEmpty(emailAddress))  {
                return View("~/Views/Shared/Error2.cshtml");
            }
            if (age == 0)
            {
                return View("~/Views/Shared/Error3.cshtml");
            }
            else if (age < 0) age = Math.Abs(age);
            if (carYear == 0)
            {
                return View("~/Views/Shared/Error4.cshtml");
            }
            else if (carYear < 0) carYear = Math.Abs(carYear);
            if (string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(carModel))  {
                return View("~/Views/Shared/Error5.cshtml");
            }
            if (string.IsNullOrEmpty(dui)) {
                return View("~/Views/Shared/Error6.cshtml");
            }
            if (string.IsNullOrEmpty(coverage))  {
                return View("~/Views/Shared/Error7.cshtml");
            }
            else
            {
                using (InsuranceEntities5 db = new InsuranceEntities5())
                {
                    var signup = new Insurance();
                    signup.FirstName = firstName;
                    signup.LastName = lastName;
                    signup.EmailAddress = emailAddress;
                    signup.Age = age;
                    if (age < 18) RunningTotal += 50;
                    else if (age < 25) RunningTotal += 25;
                    else if (age > 100) RunningTotal += 25;
                    signup.CarYear = carYear;
                    if ((carYear < 2000) || (carYear > 2015)) RunningTotal += 25;
                    signup.CarMake = carMake.ToLower();
                    if (carMake == "porsche") RunningTotal += 25;
                    signup.CarModel = carModel.ToLower();
                    if ((carMake == "porsche") && (carModel == "911 carrera" || carModel =="carrera")) RunningTotal += 25;
                    signup.SpeedingTickets = speedingTickets;
                    RunningTotal += (speedingTickets * 10);
                    signup.DUI = dui.ToLower();
                    if (dui == "yes" || dui == "y") RunningTotal += (RunningTotal / 4);
                    signup.Coverage = coverage.ToLower();
                    if(coverage == "full" || coverage == "full coverage") RunningTotal += (RunningTotal / 2);
                    signup.Quote = RunningTotal;

                    db.Insurances.Add(signup);
                    db.SaveChanges();
                }

                return View("Success");
            }
        }
    }
}