using System.Web;
using System.Web.Mvc;

namespace MVCCarInsuranceQuotes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
