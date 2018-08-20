using InsuranceApp1.Models;
using InsuranceApp1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceApp1.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            using (InsuranceEntities4 db = new InsuranceEntities4())
            {
                var signups = (from c in db.Insurances
                               where c.Removed == null
                               select c).ToList();
                var signupVms = new List<SignupVm>();
                foreach (var signup in signups)
                {
                    var signupVm = new SignupVm();
                    signupVm.Id = signup.Id;
                    signupVm.FirstName = signup.FirstName;
                    signupVm.LastName = signup.LastName;
                    signupVm.EmailAddress = signup.EmailAddress;
                    signupVm.Age = signup.Age;
                    signupVm.CarYear = signup.CarYear;
                    signupVm.CarMake = signup.CarMake;
                    signupVm.CarModel = signup.CarModel;
                    signupVm.DUI = signup.DUI;
                    signupVm.SpeedingTickets = signup.SpeedingTickets;
                    signupVm.Coverage = signup.Coverage;
                    signupVm.Quote = signup.Quote;

                    signupVms.Add(signupVm);
                }

                return View(signupVms);
            }
        }
        public ActionResult Unsubscribe(int Id)
        {
            using (InsuranceEntities4 db = new InsuranceEntities4())
            {
                var signup = db.Insurances.Find(Id);
                signup.Removed = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}