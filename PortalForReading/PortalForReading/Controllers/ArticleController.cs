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

            var articles = _service.QueryAll().Where(f => f.Title.Contains(filter)).ToList();
            var result = _mapper.Map<List<ArticleView>>(articles);

            return View(result);
        }

        //GET: Article
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(int? page, int? category)
        {
            IEnumerable<ArticleModel> articles;

            if (category != null)
            {
                articles = _service.QueryAll().Where(c => c.Categories.Any(x => x.Id == category)).ToList();
            }
            else
            {
                articles = _service.QueryAll().ToList();
            }

            var result = _mapper.Map<List<ArticleView>>(articles);

            ViewBag.Message = "Articles";

            int pageSize = 2;
            int pageNumber = (page ?? 1);

            return View("_GetArticles",result.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AuthorArticles(int author)
        {
            var articles = _service.QueryAll().Where(x => x.Author.Id == author).ToList();
            var result = _mapper.Map<List<ArticleView>>(articles);

            ViewBag.Message = "Articles";

            return View(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ReadOnline(int id, int pagenumber)
        {
            var article = _service.GetForRead(id, pagenumber);

            if (pagenumber >= 0 & pagenumber < article.PageCount)
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
                        if (pagenumber > 0)
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

                var result = _mapper.Map<ArticleBookView>(article);
                result.pagenumber = pagenumber;

                return View(result);
            }
            else
            {
                return RedirectToAction("ReadOnline", new { id = article.Id, pagenumber = 0 });
            }
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
            var result = _authorService.GetAuthors().ToList();
            SelectList authors = new SelectList(result, "Id", "Name");
            var model = new ArticleCreateView { Authors = authors };

            return View(model);
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(ArticleCreateView article, HttpPostedFileBase upload, HttpPostedFileBase upload2)
        {
            try
            {
                if (upload != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(upload.FileName);
                    // сохраняем файл в папку Files в проекте
                    upload.SaveAs(Server.MapPath("~/Resourses/" + fileName));
                    article.Img = "~/Resourses/" + fileName;
                }
                if (upload2 != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(upload2.FileName);
                    // сохраняем файл в папку Files в проекте
                    upload2.SaveAs(Server.MapPath("~/Books/" + fileName));
                    article.Book = @"Books\" + fileName;
                }
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
            var article = _service.GetById(id);
            var result = _authorService.GetAuthors().ToList();
            SelectList authors = new SelectList(result, "Id", "Name");
            var model = _mapper.Map<ArticleEditorView>(article);
            model.Authors = authors;

            return View(model);
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(ArticleCreateView article, HttpPostedFileBase upload, HttpPostedFileBase upload2)
        {
            try
            {
                // TODO: Add update logic here
                if (upload != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(upload.FileName);
                    // сохраняем файл в папку Files в проекте
                    upload.SaveAs(Server.MapPath("~/Resourses/" + fileName));
                    article.Img = "~/Resourses/" + fileName;
                }
                if (upload2 != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(upload2.FileName);
                    // сохраняем файл в папку Files в проекте
                    upload2.SaveAs(Server.MapPath("~/Books/" + fileName));
                    article.Book = @"Books\" + fileName;
                }
                var result = _mapper.Map<ArticleModel>(article);
                _service.Edite(result);

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
