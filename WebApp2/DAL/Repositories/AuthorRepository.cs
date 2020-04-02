using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public IEnumerable<Author> GetAuthors()
        {
            using (var _ctx = new MyContext())
            {
                var result = _ctx.Authors.Include(a => a.Articles).ToList();
                return result;
            }
        }
    }
}
