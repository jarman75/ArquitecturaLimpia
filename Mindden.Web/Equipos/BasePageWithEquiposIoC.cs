using System;

namespace Mindden.Web.Equipos
{
    public class BasePageWithEquipoIoC : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            EquiposIoC.BuildUp(this);
            
        }
    }
}