using System;
using System.Collections.Generic;
using Mindden.Web.Equipos.Models;
using Mindden.Equipos.Application.Interfaces;
using Mindden.Equipos.Application.DataService;
using Mindden.Equipos.Configuration;
using Mindden.Equipos.Application.Responses;
using StructureMap;

namespace Mindden.Web.Equipos.Views
{
    public partial class CrearEquipo : System.Web.UI.Page
    {

        private EquipoViewModel viewModel = new EquipoViewModel();
        public List<EquipoViewModel> listModel { get; set; }


        //public IEquipoService EquipoService { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ListarEquipos();

            }
        }

        private void ListarEquipos()
        {
            //contanier IoC SructureMap
            var container = new Container(new EquiposRegister());
            IEquipoService equipoService = container.GetInstance<IEquipoService>();

            ListarEquiposResponse response = equipoService.ListarEquipos();
            if (response.Status == StatusEnum.CorrectOperation)
            {
                listModel = new List<EquipoViewModel>();
                foreach (DtoBasicEquipo e in response.Equipos)
                {
                    listModel.Clear();
                    listModel.Add(new EquipoViewModel { NombrEquipo = e.NombreEquipo, Cliente = "", Ubicacion = "" });
                }

                this.Repeater1.DataSource = listModel;
                this.Repeater1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            viewModel.Cliente = this.TextCliente.Text;
            viewModel.NombrEquipo = this.TextName.Text;
            viewModel.Ubicacion = this.TextUbicacion.Text;

            if (!this.ModelState.IsValid)
            {
                return;
            }

            try
            {
                //contanier IoC SructureMap
                var container = new Container(new EquiposRegister());
                IEquipoService equipoService = container.GetInstance<IEquipoService>();
                                

                List<DtoDesarrollador> desarrolladores = new List<DtoDesarrollador>() { new DtoDesarrollador("Lider", "AliasLider", 20) };
                DSEquipo ds = new DSEquipo(viewModel.NombrEquipo, viewModel.Ubicacion, viewModel.Cliente, desarrolladores);
                CrearEquipoResponse response = equipoService.CrearEquipo(ds);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }
    }
}