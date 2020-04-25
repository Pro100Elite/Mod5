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
        // GET: Article
        public ActionResult Index(int? page)
        {
            var articles = _mapper.Map<List<ArticleView>>(_service.GetArticles());
            ViewBag.Message = "Articles";
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(articles.ToPagedList(pageNumber, pageSize));
        }

        // GET: Article/Details/5
        [HttpGet]
        public ActionResult ReadOnline(int id, int pagenumber)
        {
            XmlDocument xDoc = new XmlDocument();

            var article = _mapper.Map<ArticleView>(_service.GetById(id));
            var artikleBook = new ArticleBookView();

            artikleBook.Id = id;
            artikleBook.pagenumber = pagenumber;

            xDoc.Load(article.Book);
            XmlElement xRoot = xDoc.DocumentElement;

            // обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "title")
                    {
                        artikleBook.Title += childnode.InnerText;
                    }

                    if (childnode.Name == "section")
                    {
                        artikleBook.BookPagin = childnode.InnerText.Split('\n').Skip(pagenumber * artikleBook.pageSize).Take(artikleBook.pageSize).ToList();
                    }
                }
            }

                return View(artikleBook);
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
