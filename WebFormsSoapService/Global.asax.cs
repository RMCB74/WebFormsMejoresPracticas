using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;


using WebFormsSoapService.DependencyInjection;


using Microsoft.Extensions.DependencyInjection; 

namespace WebFormsSoapService
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["ServiceProvider"] =
                DependencyConfig.Configure();
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var provider =
                (ServiceProvider)Application["ServiceProvider"];

            var scope = provider.CreateScope();

            HttpContext.Current.Items["DI.Scope"] = scope;
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var scope =
                HttpContext.Current.Items["DI.Scope"] as IServiceScope;

            scope?.Dispose();
        }



    }
}