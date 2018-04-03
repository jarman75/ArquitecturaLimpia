
namespace Mindden.Equipos.Core.Entities.EquipoAggregate
{
    public class UbicacionEquipo
    {

        /// <summary>
        /// Prevents a default instance of the <see cref="UbicacionEquipo"/> class from being created.
        /// </summary>
        private UbicacionEquipo() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UbicacionEquipo"/> class.
        /// </summary>
        /// <param name="ciudad">The ciudad.</param>
        /// <param name="cliente">The cliente.</param>
        public UbicacionEquipo(string ciudad, string cliente)
        {
            this.Ubicacion = ciudad;            
            this.Cliente = cliente;
        }

        /// <summary>
        /// Gets the ciudad.
        /// </summary>
        /// <value>
        /// The ciudad.
        /// </value>
        public string Ubicacion { get; private set; }

        /// <summary>
        /// Gets the cliente.
        /// </summary>
        /// <value>
        /// The cliente.
        /// </value>
        public string Cliente { get; private set; }

    }
}
