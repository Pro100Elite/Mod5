﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IArticleRepository
    {
        Article GetById(int id);
        IEnumerable<Article> GetByAuthor(int author);
        IEnumerable<Article> GetArticles();
        IEnumerable<Article> GetArticles(int? category);

        void Create(Article article);
        void Delete(int id);
        void Update(Article article);
    }
}
