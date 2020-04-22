using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IArticleService
    {
        IEnumerable<ArticleModel> GetArticles();
        ArticleModel GetById(int id);
        void EditArticle(ArticleModel articleModel);
    }
}
