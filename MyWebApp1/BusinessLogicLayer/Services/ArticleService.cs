using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services
{
    public class ArticleService : GenereicService<ArticleModel, Article>, IArticleService
    {
        private readonly IMapper _mapper;


        public ArticleService(IGenericRepository<Article> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public override ArticleModel Map(Article entity)
        {
            return _mapper.Map<ArticleModel>(entity);
        }

        public override Article Map(ArticleModel blmodel)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ArticleModel> Map(IList<Article> entitiesList)
        {
            return _mapper.Map<IEnumerable<ArticleModel>>(entitiesList);
        }

        public override IEnumerable<Article> Map(IList<ArticleModel> entitiesList)
        {
            return _mapper.Map<IEnumerable<Article>>(entitiesList);
        }
    }
}
