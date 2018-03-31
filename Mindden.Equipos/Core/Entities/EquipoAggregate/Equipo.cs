using System;
using System.Collections.Generic;
using Mindden.Equipos.Core.Interfaces;


namespace Mindden.Equipos.Core.Entities.EquipoAggregate
{
    //Agregate Root : Raiz agregado    
    public class Equipo : BaseEquipo, IAggregateRoot
    {

        /// <summary>
        /// Prevents a default instance of the <see cref="Equipo"/> class from being created.
        /// </summary>
        private Equipo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Equipo"/> class.
        /// </summary>
        /// <param name="NombreEquipo">The nombre equipo.</param>
        /// <param name="ciudad">The ciudad.</param>
        /// <param name="cliente">The cliente.</param>
        public Equipo(string NombreEquipo, string ciudad, string cliente)
        {
            this.NombreEquipo = NombreEquipo;                        
            this.Ubicacion = new UbicacionEquipo(ciudad, cliente);
        }
        
        /// <summary>
        /// The desarrolladores
        /// </summary>
        private readonly List<DesarrolladorEquipo> _desarrolladores = new List<DesarrolladorEquipo>();

        /// <summary>
        /// Gets the lugar trabajo.
        /// </summary>
        /// <value>
        /// The lugar trabajo.
        /// </value>
        public UbicacionEquipo Ubicacion { get; private set; }

        /// <summary>
        /// Gets the desarrolladores.
        /// </summary>
        /// <value>
        /// The desarrolladores.
        /// </value>
        public IReadOnlyCollection<DesarrolladorEquipo> Desarrolladores
        {
            get
            {
                return _desarrolladores.AsReadOnly();
            }
        }

        /// <summary>
        /// Sets the ubicacion.
        /// </summary>
        /// <param name="ciudad">The ciudad.</param>
        /// <param name="cliente">The cliente.</param>
        public void SetUbicacion(string ciudad, string cliente)
        {
            this.Ubicacion = new UbicacionEquipo(ciudad, cliente);            
        }
        
        /// <summary>
        /// Adds the desarrolllador.
        /// </summary>
        /// <param name="desarrollador">The desarrollador.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// No se admiten mas desarrolladores - desarrollador
        /// or
        /// Solo puede haber un Becario en el equipo - desarrollador
        /// </exception>
        /// <exception cref="System.ArgumentException">No se admiten intrusos - desarrollador</exception>
        public void AddDesarrolllador(DesarrolladorEquipo desarrollador)
        {

            //solo se permiten 5 miembros en el equipo
            if (_desarrolladores.Count==5)
            {
                throw new ArgumentOutOfRangeException("No se admiten mas desarrolladores",nameof(desarrollador));
            }
            //solo un Becario por favor
            if (desarrollador.Perfil == PerfilDesarrollador.Becario && _desarrolladores.FindAll(x => x.Perfil == PerfilDesarrollador.Becario).Count>0)
            {
                throw new ArgumentOutOfRangeException("Solo puede haber un becario en el equipo",nameof(desarrollador));
            }
            //no se admiten intrusos
            if (desarrollador.Perfil == PerfilDesarrollador.Intruso)
            {
                throw new ArgumentException("No se admiten intrusos", nameof(desarrollador));
            }            

            _desarrolladores.Add(desarrollador);
        }

        /// <summary>
        /// Removes the desarrollador.
        /// </summary>
        /// <param name="nombre">The nombre.</param>
        /// <exception cref="System.ArgumentException">El desarrollador no se encuentra en el equipo</exception>
        public void RemoveDesarrollador(string nombre)
        {
            DesarrolladorEquipo des;
            des = _desarrolladores.Find(x => x.Nombre == nombre);

            if (des == null)            
            {
                throw new ArgumentException("El desarrollador no se encuentra en el equipo");
            }

            _desarrolladores.Remove(des);

            
        }       



    }
}
