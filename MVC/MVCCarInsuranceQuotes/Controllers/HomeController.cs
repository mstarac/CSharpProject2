using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCarInsuranceQuotes.Models;

namespace MVCCarInsuranceQuotes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Quote(string firstName, string lastName, string emailAddress, DateTime dateOfBirth, int carYear, string carMake, string carModel,
            bool DUI, int speedingTickets, bool fullCoverage, decimal finalQuote = 50)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || dateOfBirth == null ||
                carYear == 0 || string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(carModel) || speedingTickets < 0)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {

                using (CarInsurance db = new CarInsurance())
                {
                    var newQuote = new QuoteList();

                    newQuote.firstName = firstName;
                    newQuote.lastName = lastName;
                    newQuote.emailAddress = emailAddress;
                    newQuote.dateOfBirth = dateOfBirth;
                    newQuote.carYear = Convert.ToInt16(carYear);
                    newQuote.carMake = carMake;
                    newQuote.carModel = carModel;
                    newQuote.fullCoverage = fullCoverage;
                    newQuote.DUI = DUI;
                    newQuote.speedingTickets = Convert.ToInt16(speedingTickets);

                    int age = dateOfBirth.Year;
                    int month = dateOfBirth.Month;
                    int day = dateOfBirth.Day;

                    if (DateTime.Now.Month > month)
                    {
                        age = age + 1;
                    }
                    else if (DateTime.Now.Month == month && DateTime.Now.Day >= day)
                    {
                        age = age + 1;
                    }
                    if (DateTime.Now.Year - age < 18)
                    {
                        finalQuote = finalQuote + 100;
                    }
                    else if (DateTime.Now.Year - age < 25)
                    {
                        finalQuote = finalQuote + 25;
                    }
                    else if (DateTime.Now.Year - age > 100)
                    {
                        finalQuote = finalQuote + 25;
                    }
                    int year = Convert.ToInt16(carYear);
                    if (year < 2000)
                    {
                        finalQuote = finalQuote + 25;
                    }

                    carMake = carMake.ToLower();
                    carModel = carModel.ToLower();
                    if (carMake == "porsche")
                    {
                        finalQuote = finalQuote + 25;
                    }
                    if (carMake == "porsche" && carModel == "911 carerra")
                    {
                        finalQuote = finalQuote + 25;
                    }
                    finalQuote = finalQuote + 10 * speedingTickets;

                    if (DUI == true)
                    {
                        finalQuote = (finalQuote * 5) / 4;

                    }
                    if (fullCoverage == true)
                    {

                        finalQuote = (finalQuote * 3) / 2;
                    }
                    newQuote.finalQuote = Convert.ToInt16(finalQuote);

                    db.QuoteLists.Add(Quote);

                    db.SaveChanges();
                }

                return View("Success");
            }
        }
    }  
        
    }
