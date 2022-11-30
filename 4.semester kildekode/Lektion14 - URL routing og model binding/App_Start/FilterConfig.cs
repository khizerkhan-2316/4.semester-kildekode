using System.Web;
using System.Web.Mvc;

namespace Lektion14___URL_routing_og_model_binding
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
