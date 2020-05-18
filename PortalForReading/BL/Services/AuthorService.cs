using AutoMapper;
using BL.Interfaces;
using BL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class AuthorService: IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository articleRepository, IMapper mapper)
        {
            _repository = articleRepository;
            _mapper = mapper;
        }

        public IEnumerable<AuthorModel> GetAuthors()
        {
            var authors = _repository.GetAuthors();
            var result = _mapper.Map<IEnumerable<AuthorModel>>(authors);

            return result;
        }

        public Dictionary<int, string> GetAuthorDictionary()
        {
            var result = _repository.GetAuthors().ToDictionary(x => x.Id, x => x.Name);

            return result;
        }
    }
}
