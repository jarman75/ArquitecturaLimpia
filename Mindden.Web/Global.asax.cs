using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Mindden.Equipos.Configuration;

namespace Mindden.Web
{
    public class Global : HttpApplication
    {
        //protected override IKernel CreateKernel()
        //{
        //    var kernel = new StandardKernel();
        //    kernel.Load(new EquiposKernel());
        //    return kernel;
        //}

        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //config components            
            EquipoComponent.Load();

            //dependencias
            //NinjectWebCommon.RegisterServices(new StandardKernel());





        }
    }
}