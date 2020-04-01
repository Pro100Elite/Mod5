using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using LightInject;

namespace BusinessLogicLayer
{
    public static class BLLightInjectCongiguration
    {
        public static ServiceContainer Congiguration(ServiceContainer container)
        {
            container.Register(typeof(MyContext<>), typeof(MyContext<>));
            //container.Register<DbContext>(factory => new DbContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=WebDB;Integrated Security=True"));
            container.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return container;
        }
    }
}
