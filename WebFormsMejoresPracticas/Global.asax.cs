using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WebFormsMejoresPracticas.Infrastructure.DependencyInjection;


using WebFormsMejoresPracticas.Infrastructure.Logging;



namespace WebFormsMejoresPracticas
{
    public class Global : HttpApplication
    {

        public static ServiceProvider ServiceProvider { get; private set; }


        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            

            LoggerConfig.Configure();


            Log.Information("Aplicación iniciada correctamente.");


            ServiceProvider = DependencyConfig.Configure(); 

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var scope = ServiceProvider.CreateScope();

            HttpContext.Current.Items["DI.Scope"] = scope;
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var scope = HttpContext.Current.Items["DI.Scope"]
                as IServiceScope;

            scope?.Dispose();
        }


    }
}