using StructureMap;
using Mindden.Equipos.Configuration;




namespace Mindden.Web
{
    public static class EquiposIoC
    {
        private static readonly IContainer _container;

        static EquiposIoC()
        {
            _container = new Container(new EquiposRegistry());            
        }        

        public static T Resolve<T>()
        {
            return _container.GetInstance<T>();
        }

        public static T Resolve<T>(string name)
        {
            return _container.GetInstance<T>(name);
        }

        public static void BuildUp(object target)
        {
            _container.BuildUp(target);
        }

        // helper method that shows what's in the container
        public static string WhatDoIHave()
        {
            return _container.WhatDoIHave();
        }
    }
}