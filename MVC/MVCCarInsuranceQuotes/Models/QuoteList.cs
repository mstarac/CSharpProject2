using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCarInsuranceQuotes.Models
{
    public class QuoteList
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int carYear { get; set; }
        public string carMake { get; set; }
        public string carModel { get; set; }
        public Nullable<bool> fullCoverage { get; set; }
        public Nullable<bool> DUI { get; set; }
        public int speedingTickets { get; set; }
        public int finalQuote { get; set; }
       


    }
}