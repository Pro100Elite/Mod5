using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CategoryRepository: ICategoryRepository, IDisposable
    {
        private readonly IMyContext _ctx;

        public CategoryRepository(IMyContext context)
        {
            _ctx = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            var result = _ctx.Categories.Include(c => c.Articles);

            return result;
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
