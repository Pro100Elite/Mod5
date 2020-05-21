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

        public IQueryable<AuthorModel> GetAuthors()
        {
            var query = _repository.GetAuthors();
            var result = _mapper.ProjectTo<AuthorModel>(query);

            return result;
        }
    }
}
