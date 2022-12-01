using System.Web;
using System.Web.Mvc;

namespace Asp.net_MVC_Crud_using_Entity_Framework_DB_First
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
