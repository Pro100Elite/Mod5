using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Interfaces;
using BL.Models;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;

namespace BL.Services
{
    public class ArticleService: IArticleService
    {
        private readonly IArticleRepository _repository;

        public ArticleService()
        {
            _repository = new ArticleRepository();
        }

        public IEnumerable<ArticleModel> GetArticles()
        {
            var config = new MapperConfiguration(con => con.CreateMap<Article, ArticleModel>());

            var mapper = new Mapper(config);

            var articles = mapper.Map<IEnumerable<ArticleModel>>(_repository.GetArticles());

            return articles;
        }
    }
}
