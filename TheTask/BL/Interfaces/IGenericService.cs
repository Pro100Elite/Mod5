using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IGenericService<BLModel> where BLModel: class
    {
        IEnumerable<BLModel> Get();
        BLModel FindById(int id);
    }
}
