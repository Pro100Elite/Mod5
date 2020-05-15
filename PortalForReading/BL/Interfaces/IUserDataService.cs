using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUserDataService
    {
        UserDataModel GetById(string accountId, int bookId);
        void Create(UserDataModel userData);
        void Update(UserDataModel userData);
    }
}
