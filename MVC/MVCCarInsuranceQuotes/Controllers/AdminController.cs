using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCarInsuranceQuotes.Models;
using MVCCarInsuranceQuotes.ViewModels;



namespace MVCCarInsuranceQuotes.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarInsurance db = new CarInsurance())
            {

                var quotes = db.QuoteLists.ToList();
                var quotesVms = new List<QuoteList>();
                foreach (var newQuote in quotes)
                {
                    var quoteVm = new QuoteList();
                    quoteVm.firstName = newQuote.firstName;
                    quoteVm.lastName = newQuote.lastName;
                    quoteVm.emailAddress = newQuote.emailAddress;
                    quoteVm.finalQuote = newQuote.finalQuote;
                    quotesVms.Add(quoteVm);

                }
                return View(quotesVms);
            }
        }
    }
}