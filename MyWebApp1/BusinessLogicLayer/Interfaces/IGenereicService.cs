using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IGenereicService<Model> where Model : class
    {
        IEnumerable<Model> GetAll();
    }
}
