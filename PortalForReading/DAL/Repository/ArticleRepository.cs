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
    public class ArticleRepository : IArticleRepository
    {
        private readonly IMyContext _ctx;

        public ArticleRepository(IMyContext context)
        {
            _ctx = context;
        }

        public Article GetById(int id)
        {
            using (var _ctx = new MyContext())
            {
                return _ctx.Articles.Find(id);
            }
        }

        public IEnumerable<Article> GetByAuthor(int author)
        {
            using (var _ctx = new MyContext())
            {
                return _ctx.Articles.Where(x => x.Author.Id == author).Include(a => a.Author)
                    .Include(c => c.Categories).ToList();
            }
        }

        public IEnumerable<Article> GetArticles()
        {
            using (_ctx)
            {
                var result = _ctx.Articles.Include(a => a.Author).Include(c => c.Categories).ToList();

                return result;
            }
        }

        public IEnumerable<Article> GetArticles(int? category)
        {
            using (_ctx)
            {
                var result = _ctx.Articles.Where(c => c.Categories.Any(x => x.Id == category))
                    .Include(a => a.Author).Include(c => c.Categories).ToList();

                return result;
            }
        }

        public void Create(Article article)
        {
            using (_ctx)
            {
                _ctx.Articles.Add(article);

                _ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (_ctx)
            {
                _ctx.Articles.Remove(GetById(id));

                _ctx.SaveChanges();
            }
        }

        public void Update(Article article)
        {
            using (_ctx)
            {
                _ctx.Entry(article).State = EntityState.Modified;

                _ctx.SaveChanges();
            }
        }
    }
}
