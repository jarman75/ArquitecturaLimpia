using System;
using Xunit;
using Mindden.Equipos.Core.Entities.EquipoAggregate;

namespace Mindden.Equipos.Tests.Core
{

    public class EquipoTest
    {
        
    
        [Fact]
        public void EquipoInstanceTest()
        {

            string nombre = "ZeusTeam";
            string ciudad = "Alicante";
            string cliente = "Suez";

            Equipo equipo = new Equipo(nombre,ciudad,cliente);

            Assert.True(equipo.NombreEquipo == nombre, "Set nombre incorrecto");
            Assert.True(equipo.Ubicacion.Ubicacion == ciudad, "Set ciudad incorrecto");
            Assert.True(equipo.Ubicacion.Cliente == cliente, "Set cliente incorrecto");

        }       

        [Fact]
        public void EquipoMaximoExcepcion()
        {

            //validacion maximo 5 miembros
            string nombre = "DreamTeam";
            string ciudad = "Alicante";
            string cliente = "Suez";
            Equipo equipo = new Equipo(nombre,ciudad,cliente);
            Exception ex = new Exception();
            for (int i = 0; i < 10; i++)
            {
                DesarrolladorEquipo desarrollador = new DesarrolladorEquipo("miembro" + i, "Alias"+i, 14);
                
                if (i == 5)
                {
                    ex = Assert.Throws<ArgumentOutOfRangeException>(() => equipo.AddDesarrolllador(desarrollador));
                    Assert.Contains("No se admiten mas desarrolladores", ex.Message);
                    break;
                }
                else
                {
                    equipo.AddDesarrolllador(desarrollador);
                }

            }

            
        }

        [Fact]        
        public void EquipoIntrusoExcepcion()
        {
            //validacion intruso
            string nombre = "DreamTeam";
            string ciudad = "Alicante";
            string cliente = "Suez";
            Equipo equipo = new Equipo(nombre, ciudad, cliente);
            DesarrolladorEquipo desarrollador = new DesarrolladorEquipo("intruso", "teleco", -1);
            Exception ex = Assert.Throws<ArgumentException> (()=>equipo.AddDesarrolllador(desarrollador));

            Assert.Contains("No se admiten intrusos", ex.Message);
        }

        [Fact]
        public void EquipoBecarioMaximoExcepcion()
        {
            //maximo de becarios
            string nombre = "DreamTeam";
            string ciudad = "Alicante";
            string cliente = "Suez";
            Equipo equipo = new Equipo(nombre, ciudad, cliente);
            DesarrolladorEquipo desarrollador1 = new DesarrolladorEquipo("Raul", "chinpa", 0);
            DesarrolladorEquipo desarrollador2 = new DesarrolladorEquipo("Vicente", "mono", 0);
            equipo.AddDesarrolllador(desarrollador1);

            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(()=>equipo.AddDesarrolllador(desarrollador2));
            Assert.Contains("Solo puede haber un becario en el equipo", ex.Message);
        }       

        [Fact]        
        public void RemoveDesarrolladorTest()
        {

            string nombre = "DreamTeam";
            string ciudad = "Alicante";
            string cliente = "Suez";
            Equipo equipo = new Equipo(nombre, ciudad, cliente);
            for (int i = 0; i < 5; i++)
            {
                DesarrolladorEquipo desarrollador = new DesarrolladorEquipo("miembro" + i, "Alias" + i, 10);
                equipo.AddDesarrolllador(desarrollador);
            }
            
            equipo.RemoveDesarrollador("miembro1");
            Assert.True(equipo.Desarrolladores.Count == 4);
            


        }

        [Fact]
        public void RemoveDesarrolladorExceptionTest()
        {

            string nombre = "DreamTeam";
            string ciudad = "Alicante";
            string cliente = "Suez";
            Equipo equipo = new Equipo(nombre, ciudad, cliente);
            for (int i = 0; i < 5; i++)
            {
                DesarrolladorEquipo desarrollador = new DesarrolladorEquipo("miembro" + i, "Alias" + i, 7);
                equipo.AddDesarrolllador(desarrollador);
            }            
            
            Exception ex = Assert.Throws<ArgumentException> (() =>  equipo.RemoveDesarrollador("noexiste"));
            Assert.Contains("El desarrollador no se encuentra en el equipo", ex.Message);
            

        }
    }
}