using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class AuthorRepository: IAuthorRepository, IDisposable
    {
        private readonly IMyContext _ctx;

        public AuthorRepository(IMyContext context)
        {
            _ctx = context;
        }

        public IQueryable<Author> GetAuthors()
        {
            var result = _ctx.Authors.AsNoTracking();

            return result;
        }

        public Author GetById(int id)
        {
            return _ctx.Authors.Find(id);
        }

        public void Create(Author author)
        {
            _ctx.Authors.Add(author);

            _ctx.SaveChanges();
        }


        public void Delete(int id)
        {
            var result = GetById(id);
            _ctx.Authors.Remove(result);

            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
