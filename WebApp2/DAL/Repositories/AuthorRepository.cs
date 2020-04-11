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
        private readonly IMyContext _ctx;

        public AuthorRepository(IMyContext context)
        {
            _ctx = context;
        }

        public IEnumerable<Author> GetAuthors()
        {
            using (_ctx)
            {
                var result = _ctx.Authors.Include(a => a.Articles).ToList();
                return result;
            }
        }

        public void Create(Author author)
        {
            using (_ctx)
            {
                _ctx.Authors.Add(author);
                _ctx.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (_ctx)
            {
                var deleteItem = _ctx.Authors.Find(Id);
                _ctx.Authors.Remove(deleteItem);
                _ctx.SaveChanges();
            }
        }
    }
}
