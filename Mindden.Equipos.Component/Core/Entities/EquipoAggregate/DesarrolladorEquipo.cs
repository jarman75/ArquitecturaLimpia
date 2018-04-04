using Mindden.Equipos.Core.Common;
using System;

namespace Mindden.Equipos.Core.Entities.EquipoAggregate
{
    public class DesarrolladorEquipo : BaseEntity  
    {

        /// <summary>
        /// Prevents a default instance of the <see cref="DesarrolladorEquipo"/> class from being created.
        /// </summary>
        private DesarrolladorEquipo() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DesarrolladorEquipo"/> class.
        /// </summary>
        /// <param name="nombre">The nombre.</param>
        /// <param name="alias">The alias.</param>
        /// <param name="perfil">The perfil.</param>
        public DesarrolladorEquipo(string nombre, string alias, int experiencia)
        {
            Nombre = nombre;
            Alias = alias;            
            Experiencia = experiencia;
            Perfil = ObtenerPerfilPorExperiencia(experiencia);
        }

        /// <summary>
        /// Gets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public String Nombre { get; private set; }

        /// <summary>
        /// Gets the alias.
        /// </summary>
        /// <value>
        /// The alias.
        /// </value>
        public String Alias { get; private set; }

        /// <summary>
        /// Gets the perfil.
        /// </summary>
        /// <value>
        /// The perfil.
        /// </value>
        public PerfilDesarrollador Perfil { get; private set; }

        /// <summary>
        /// Gets the experiencia.
        /// </summary>
        /// <value>
        /// The experiencia.
        /// </value>
        public int Experiencia { get; private set; }
        
        private static PerfilDesarrollador ObtenerPerfilPorExperiencia(int experiencia)
        {
            PerfilDesarrollador perfil = PerfilDesarrollador.Intruso;

            if (experiencia == 0) perfil = PerfilDesarrollador.Becario;
            if (experiencia >= 1 && experiencia <= 2) perfil = PerfilDesarrollador.Junior;
            if (experiencia > 2 && experiencia <= 10) perfil = PerfilDesarrollador.Senior;
            if (experiencia > 10 && experiencia <= 15) perfil = PerfilDesarrollador.Analista;
            if (experiencia > 15) perfil = PerfilDesarrollador.Arquitecto;

            return perfil;
        }

    }
}
