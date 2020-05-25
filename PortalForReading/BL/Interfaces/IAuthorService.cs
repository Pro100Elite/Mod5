using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IAuthorService
    {
        IQueryable<AuthorModel> GetAuthors();
        Dictionary<int, string> GetAuthorToDelete();
        void Delete(int id);
        void Create(AuthorModel author);
    }
}
