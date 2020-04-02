using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public Article GetById(int id)
        {
            using (var _ctx = new MyContext())
            {
                return _ctx.Articles.Find(id);
            }
        }

        public IEnumerable<Article> GetArticles()
        {
            using (var _ctx = new MyContext())
            {
                var result = _ctx.Articles.ToList();
                return result;
            }
        }

        public void Create(Article article)
        {
            using (var _ctx = new MyContext())
            {
                _ctx.Articles.Add(article);
                _ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var _ctx = new MyContext())
            {
                _ctx.Articles.Remove(GetById(id));
                _ctx.SaveChanges();
            }
        }

        public void Update(Article article)
        {
            using (var _ctx = new MyContext())
            {
                _ctx.Entry(article).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
        }
    }
}
