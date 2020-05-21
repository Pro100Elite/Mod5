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
    public class ArticleRepository : IArticleRepository, IDisposable
    {
        private readonly IMyContext _ctx;

        public ArticleRepository(IMyContext context)
        {
            _ctx = context;
        }

        public IQueryable QueryAll()
        {
            var query = _ctx.Articles.Include(a => a.Author)
                .Include(c => c.Categories).AsNoTracking();

            return query;
        }

        public Article GetById(int id)
        {
            return _ctx.Articles.Find(id);
        }

        public IEnumerable<Article> GetByAuthor(int author)
        {
            return _ctx.Articles.Where(x => x.Author.Id == author).Include(a => a.Author)
                .Include(c => c.Categories).AsNoTracking().ToList();
        }

        public void Create(Article article)
        {
            _ctx.Articles.Add(article);

            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = GetById(id);
            _ctx.Articles.Remove(result);

            _ctx.SaveChanges();
        }

        public void Update(Article article)
        {
            _ctx.Entry(article).State = EntityState.Modified;

            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
