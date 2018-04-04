using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Services.Description;
using Mindden.Equipos.Configuration;

namespace Mindden.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            //config components
            EquiposIoC.BuildUp(this);
            EquiposDataMap.Register();
                       

            EquiposEFContext.ConfigureServices();
        }
    }
}