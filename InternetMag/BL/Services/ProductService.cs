using BL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repository;

        public ProductService()
        {
            _repository = new ProductRepository();
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            var result = _repository.GetProducts()
                .Select(x => new ProductModel { Id = x.Id, categoryId = x.categoryId, Name = x.Name, Price = x.Price });
            return result;
        }

    }
}
