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
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository articleRepository, IMapper mapper)
        {
            _repository = articleRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            var category = _repository.GetCategories();
            var result = _mapper.Map<IEnumerable<CategoryModel>>(category);

            return result;
        }
    }
}
