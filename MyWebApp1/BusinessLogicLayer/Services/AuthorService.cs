//using BusinessLogicLayer.Interfaces;
//using BusinessLogicLayer.Models;
//using DataAccessLayer.Interfaces;
//using DataAccessLayer.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BusinessLogicLayer.Services
//{
//    public class AuthorService : IAuthorService
//    {
//        private readonly IAuthorRepository _authorRepository;

//        public AuthorService()
//        {
//            _authorRepository = new AuthorRepository();
//        }

//        public IEnumerable<AuthorModel> GetAuthors()
//        {
//            var result = _authorRepository.GetAuthors()
//                .Select(x => new AuthorModel { Id = x.Id, Name = x.Name, Articles = x.Articles
//                .Select(a => new ArticleModel { Id = a.Id, Title = a.Title, Txt = a.Txt })
//                .ToList()});
//            return result;
//        }
//    }
//}
