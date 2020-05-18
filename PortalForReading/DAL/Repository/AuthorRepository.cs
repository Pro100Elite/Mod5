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

        public IEnumerable<Author> GetAuthors()
        {
            var result = _ctx.Authors.AsNoTracking().ToList();

            return result;
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
