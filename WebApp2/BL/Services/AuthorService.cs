using AutoMapper;
using BL.Interfaces;
using BL.Models;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _repository = authorRepository;
            _mapper = mapper;
        }

        public IEnumerable<AuthorModel> GetAuthors()
        {
            var authors = _mapper.Map<IEnumerable<AuthorModel>>(_repository.GetAuthors());

            return authors;
        }

        public void Create(AuthorModel authorModel)
        {
            var author = _mapper.Map<Author>(authorModel);
            _repository.Create(author);
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }
    }
}
