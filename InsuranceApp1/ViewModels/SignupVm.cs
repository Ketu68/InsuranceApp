using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceApp1.ViewModels
{
    public class SignupVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string DUI { get; set; }
        public int SpeedingTickets { get; set; }
        public string Coverage { get; set; }
        public int Quote { get; set; }
    }
}