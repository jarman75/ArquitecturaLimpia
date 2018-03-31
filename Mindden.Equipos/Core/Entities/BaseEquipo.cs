using System;

namespace Mindden.Equipos.Core.Entities
{
    public class BaseEquipo : BaseEntity
    {
        
        /// <summary>
        /// The nombre equipo
        /// </summary>
        private string _nombreEquipo;

        /// <summary>
        /// Gets or sets the nombre equipo.
        /// </summary>
        /// <value>
        /// The nombre equipo.
        /// </value>
        /// <exception cref="System.ArgumentException">Nombre de equipo requerido. - NombreEquipo</exception>
        public String NombreEquipo
        {
            get { return _nombreEquipo; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Nombre de equipo requerido.", nameof(NombreEquipo));
                }
                _nombreEquipo = value;
            }
        }
    }
}
