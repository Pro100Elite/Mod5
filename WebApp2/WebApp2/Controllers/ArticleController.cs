using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BL.Interfaces;
using BL.Models;
using BL.Services;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _service;

        public ArticleController()
        {
            _service = new ArticleService();
        }
        // GET: Article
        public ActionResult Index()
        {

            var config = new MapperConfiguration(con => con.CreateMap<ArticleModel, ArticleViewModel>());

            var mapper = new Mapper(config);

            var articles = mapper.Map<List<ArticleViewModel>>(_service.GetArticles());

            ViewBag.Message = "Articles";
            return View(articles);
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
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

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(ArticleModel articleModel)
        {
            try
            {
                // TODO: Add update logic here
                _service.EditArticle(articleModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Article/Delete/5
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
