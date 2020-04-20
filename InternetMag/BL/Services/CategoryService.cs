using BL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _repository;

        public CategoryService()
        {
            _repository = new CategoryRepository();
        }

        public Dictionary<int, string> GetCategory()
        {
            var result = _repository.GetCategories().ToDictionary(x => x.Id, x => x.Name);
            return result;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            var result = _repository.GetCategories()
                .Select(x => new CategoryModel { Id = x.Id, Name = x.Name });
            return result;
        }
    }
}
