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
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _repository = articleRepository;
            _mapper = mapper;
        }

        public IEnumerable<ArticleModel> GetArticles()
        {
            var articles = _mapper.Map<IEnumerable<ArticleModel>>(_repository.GetArticles());

            return articles;
        }

        public void EditArticle(ArticleModel articleModel)
        {
            var article = _mapper.Map<Article>(articleModel);

            _repository.Update(article);
        }
    }
}
