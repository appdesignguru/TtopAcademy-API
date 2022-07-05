using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TtopAcademy.API.App_Start;

namespace TtopAcademy.API
{
    /// <summary> Entry point for the web api. </summary> 
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary> Configures the needed dependencies. </summary>
        protected void Application_Start()
        {
            IocConfig.Configure(); // Dependency injection class
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
