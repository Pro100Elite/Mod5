using AutoMapper;
using BL.Interfaces;
using PagedList;
using PortalForReading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace PortalForReading.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _service;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _service = articleService;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult Filter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Filter(string filter)
        {
            ViewBag.filter = filter;

            var articles = _service.GetArticles(null);
            var result = _mapper.Map<List<ArticleView>>(articles);

            result = ViewBag.filter == null ? result : result.Where(f => f.Title.Contains(ViewBag.filter)).ToList();

            return View(result);
        }

        //GET: Article
        [HttpGet]
        public ActionResult Index(int? page, int? category, string filter = null)
        {
            var articles = _service.GetArticles(category);
            var result = _mapper.Map<List<ArticleView>>(articles);

            ViewBag.Message = "Articles";
            int pageSize = 2;
            int pageNumber = (page ?? 1);

            return View("_GetArticles",result.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult AuthorArticles(int author)
        {
            var articles = _service.GetByAuthor(author);
            var result = _mapper.Map<List<ArticleView>>(articles);

            ViewBag.Message = "Articles";

            return View(result);
        }

        // GET: Article/Details/5
        [HttpGet]
        public ActionResult ReadOnline(int id, int pagenumber)
        {
            var article = _service.GetForRead(id, pagenumber);
            var result = _mapper.Map<ArticleBookView>(article);

            result.pagenumber = pagenumber;

            return View(result);
        }

        [Authorize(Roles = "admin")]
        public FileResult DownLoad(int id)
        {
            var article = _service.GetById(id);
            var result = _mapper.Map<ArticleBookView>(article);
            // Путь к файлу
            string file_path = Server.MapPath($@"\{result.Book}");
            // Тип файла - content-type
            string file_type = "application/pdf";
            // Имя файла - необязательно
            string file_name = $"{result.Title}.pdf";

            return File(file_path, file_type, file_name);
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
