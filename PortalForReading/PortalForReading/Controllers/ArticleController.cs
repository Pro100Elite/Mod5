using AutoMapper;
using BL.Interfaces;
using BL.Models;
using PagedList;
using PortalForReading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace PortalForReading.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _service;
        private readonly IUserDataService _serviceData;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, IUserDataService userData, IAuthorService authorService, IMapper mapper)
        {
            _service = articleService;
            _serviceData = userData;
            _authorService = authorService;
            _mapper = mapper;
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult Filter()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Filter(string filter)
        {

            var articles = _service.Filter(filter);
            var result = _mapper.Map<List<ArticleView>>(articles);

            return View(result);
        }

        //GET: Article
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(int? page, int? category, string filter = null)
        {

            var articles = _service.GetArticles(category);
            var result = _mapper.Map<List<ArticleView>>(articles);

            ViewBag.Message = "Articles";
            ViewBag.Page = 0;

            int pageSize = 2;
            int pageNumber = (page ?? 1);

            return View("_GetArticles",result.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AuthorArticles(int author)
        {
            var articles = _service.GetByAuthor(author);
            var result = _mapper.Map<List<ArticleView>>(articles);

            ViewBag.Message = "Articles";

            return View(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ReadOnline(int id, int pagenumber)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var userIdValue = userIdClaim.Value;
                    if(pagenumber > 0)
                    {
                        var resultData = new UserDataModel { AccountId = userIdValue, BookId = id, BookPage = pagenumber };
                        _serviceData.Update(resultData);
                    }

                    var userData = _serviceData.GetById(userIdValue, id);

                    if (pagenumber == 0 & userData != null)
                    {
                        pagenumber = userData.BookPage;
                    }
                }
            }

            var article = _service.GetForRead(id, pagenumber);
            var result = _mapper.Map<ArticleBookView>(article);
            result.pagenumber = pagenumber;

            return View(result);
        }


        [Authorize(Roles = "user")]
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
            //            ViewBag.Author = _authorService.GetAuthorDictionary()
            //.Select(x => new SelectListItem { Value = x.Key.ToString(), Text = x.Value });

            var result = _authorService.GetAuthors();
            SelectList authors = new SelectList(result, "Id", "Name");
            //ViewBag.Author = authors;
            var model = new ArticleCreateView { Authors = authors };

            return View(model);
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(ArticleCreateView article)
        {
            try
            {
                var result = _mapper.Map<ArticleModel>(article);
                _service.Create(result);

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

        // GET: Author/Delete/5
        //[HttpGet]
        public ActionResult Delete()
        {
            ViewBag.Article = _service.GetArticleToDelete()
                .Select(x => new SelectListItem { Value = x.Key.ToString(), Text = x.Value });
            return View();
        }

        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
