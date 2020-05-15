using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserDataRepository
    {
        UserData GetById(string accountId, int bookId);
        void Create(UserData userData);
        void Update(UserData userData);
    }
}
