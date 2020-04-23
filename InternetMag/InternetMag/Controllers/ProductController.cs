using BL.Services;
using InternetMag.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InternetMag.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;
        private readonly CategoryService _categoryService;

        private readonly RestClient _restClient;
        private string apiURL = "api/Product";

        public ProductController()
        {
            _service = new ProductService();
            _categoryService = new CategoryService();
            _restClient = new RestClient("http://local.blog");
        }

        [HttpGet]
        public ActionResult Cat()
        {
            ViewBag.Categ = _categoryService.GetCategory()
.Select(x => new SelectListItem { Value = x.Key.ToString(), Text = x.Value });
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Cat(int Id)
        {
            if (Id == 0)
            {
                return RedirectToAction("All");
            }
            else
            {
                return RedirectToAction("Index", new { id = Id });
            }
        }

        //GET: Product
        [HttpGet]
        public ActionResult All()
        {
            var request = new RestRequest(apiURL);
            var responseData = _restClient.Execute<List<ProductsView>>(request, Method.GET).Data;
            return View(responseData);
        } 
        
        //[HttpGet]
        //public ActionResult All()
        //{
        //    var products = _service.GetProducts()
        //        .Select(x => new ProductsView { Id = x.Id, categoryId = x.categoryId, Name = x.Name, Price = x.Price }).ToList();

        //    return View(products);
        //}


        [HttpGet]
        public ActionResult Index(int id)
        {
            var products = _service.GetProducts().Where(x => x.categoryId == id)
                .Select(x => new ProductsView { Id = x.Id, categoryId = x.categoryId, Name = x.Name, Price = x.Price }).ToList();

            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
