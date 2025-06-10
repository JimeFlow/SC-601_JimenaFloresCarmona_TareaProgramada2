using System.Web;
using System.Web.Mvc;

namespace TP2_Trigonomeria_Triangulos
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
