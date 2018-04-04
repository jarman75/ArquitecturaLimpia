using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Mindden.Web.Equipos.Models;
using Mindden.Equipos.Application.Interfaces;
using Mindden.Equipos.Application.DataService;
using Mindden.Equipos.Core.Interfaces;


namespace Mindden.Web.Equipos.Views
{
    public partial class CrearEquipo : BasePageWithEquipoIoC
    {
        
        public IEquipoRepository EquipoRepository { get; set; }
        public IEquipoService EquipoService { get; set; }        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            base.OnLoad(e);

            this.FormView1.ChangeMode(FormViewMode.Insert);

            
        }

        public void InsertItem(EquipoViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return;
            }

            try
            {

                List<DtoDesarrollador> desarrolladores = new List<DtoDesarrollador>() { new DtoDesarrollador("Lider", "AliasLider", 20) };
                DSEquipo ds = new DSEquipo(viewModel.NombrEquipo, viewModel.Ubicacion, viewModel.Cliente, desarrolladores);
                EquipoService.CrearEquipo(ds);
            }
            catch
            {

            }
        }

        

        
    }
}