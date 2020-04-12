using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors();
        void Create(Author author);
        void Delete(int Id);
        //Dictionary<int, string> GetAuthorsToDelete();
    }
}
