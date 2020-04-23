using BL.Services;
using InternetMagApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InternetMagApi.Controllers
{
    public class ProductController : ApiController
    {

        private readonly ProductService _service;
        private readonly CategoryService _categoryService;

        public ProductController()
        {
            _service = new ProductService();
            _categoryService = new CategoryService();
        }
        // GET: api/Product
        public IEnumerable<ProductApi> Get()
        {
            var products = _service.GetProducts()
               .Select(x => new ProductApi { Id = x.Id, categoryId = x.categoryId, Name = x.Name, Price = x.Price }).ToList();

            return products;
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
