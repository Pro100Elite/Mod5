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
    public class AuthorService: IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService()
        {
            _repository = new AuthorRepository();
        }

        public IEnumerable<AuthorModel> GetAuthors()
        {
            var config = new MapperConfiguration(con => con.CreateMap<Author, AuthorModel>());

            var mapper = new Mapper(config);

            var authors = mapper.Map<IEnumerable<AuthorModel>>(_repository.GetAuthors());

            return authors;
        }
    }
}
