﻿using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IArticleService
    {
        IQueryable<ArticleModel> QueryAll();

        ArticleModel GetById(int id);
        ArticleReadModel GetForRead(int id, int pagenumber);
        void Create(ArticleModel articleModel);
        void Delete(int Id);
        void Edite(ArticleModel articleModel);
        Dictionary<int, string> GetArticleToDelete();
    }
}
