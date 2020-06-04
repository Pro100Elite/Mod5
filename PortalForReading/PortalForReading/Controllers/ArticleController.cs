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
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        private const int startPage = 0;

        public ArticleController(IArticleService articleService, IUserDataService userData,
            IAuthorService authorService, ICategoryService categoryService, IMapper mapper)
        {
            _service = articleService;
            _serviceData = userData;
            _categoryService = categoryService;
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
                articles = _service.QueryAll().Where(c => c.ArticleCategories.Any(x => x.CategoryId == category)).ToList();
                ViewBag.category = category;
            }
            else
            {
                articles = _service.QueryAll().ToList();
            }

            var result = _mapper.Map<List<ArticleView>>(articles);

            ViewBag.Message = "Articles";

            int pageSize = 2;
            int pageNumber = (page ?? 1);

            return View("_GetArticles", result.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult News()
        {
            var articles = _service.QueryAll().OrderByDescending(x => x.DatePost).Take(3);
            var result = _mapper.Map<List<ArticleView>>(articles);

            return View(result);
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
            var article = _service.GetForRead(id, startPage);

            if (pagenumber >= startPage & pagenumber < article.PageCount)
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
                        if (pagenumber > startPage)
                        {
                            var resultData = new UserDataModel { AccountId = userIdValue, BookId = id, BookPage = pagenumber };
                            _serviceData.Update(resultData);
                        }

                        var userData = _serviceData.GetById(userIdValue, id);
                        if (pagenumber == startPage & userData != null)
                        {
                            pagenumber = userData.BookPage;
                        }
                    }
                }

                article = _service.GetForRead(id, pagenumber);
                var result = _mapper.Map<ArticleBookView>(article);
                result.pagenumber = pagenumber;

                return View(result);
            }
            else
            {
                return RedirectToAction("ReadOnline", new { id = article.Id, pagenumber = startPage });
            }
        }


        [Authorize(Roles = "user")]
        public FileResult DownLoad(int id)
        {
            string typePDF = "application/pdf";
            var article = _service.GetById(id);
            var result = _mapper.Map<ArticleBookView>(article);

            string file_path = Server.MapPath($@"\{result.Book}");

            string file_type = typePDF;

            string file_name = $"{result.Title}.pdf";

            return File(file_path, file_type, file_name);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            var resultAuthors = _authorService.GetAuthors().ToList();
            var resultCategories = _categoryService.GetCategories().ToList();
            SelectList authors = new SelectList(resultAuthors, "Id", "Name");
            SelectList categories = new SelectList(resultCategories, "Id", "Title");
            var model = new ArticleCreateView { Authors = authors, Categories = categories };

            return View(model);
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(ArticleCreateView article, params int[] selectedCategories)
        {

            if (string.IsNullOrEmpty(article.Title))
            {
                ModelState.AddModelError("Title", "Required field");
            }

            if (string.IsNullOrEmpty(article.Txt))
            {
                ModelState.AddModelError("Txt", "Required field");
            }


            if (article.UploadImg != null)
            {
                if (article.UploadImg.ContentType == "image/jpeg")
                {
                    string fileName = System.IO.Path.GetFileName(article.UploadImg.FileName);

                    article.UploadImg.SaveAs(Server.MapPath("~/Resourses/" + fileName));
                    article.Img = "~/Resourses/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("UploadImg", "Incorrect image format");
                }
            }
            else
            {
                ModelState.AddModelError("UploadImg", "Please select file");
            }



            if (article.UploadBook != null)
            {
                if (article.UploadBook.ContentType == "application/pdf")
                {

                    string fileName = System.IO.Path.GetFileName(article.UploadBook.FileName);
                    article.UploadBook.SaveAs(Server.MapPath("~/Books/" + fileName));
                    article.Book = @"Books\" + fileName;
                }
                else
                {
                    ModelState.AddModelError("UploadBook", "Incorrect book format (pdf only)");
                }
            }
            else
            {
                ModelState.AddModelError("UploadBook", "Please select file");
            }           

            if (article.Categories == null)
            {
                ModelState.AddModelError("Categories", "Please select Categories");
            }

            if (ModelState.IsValid)
            {
                article.DatePost = DateTime.Now;
                var articleMap = _mapper.Map<ArticleModel>(article);
                articleMap.ArticleCategories = new List<CategoryArticleModel>();

                foreach (var cat in selectedCategories)
                {
                    var category = new CategoryArticleModel { CategoryId = cat };
                    articleMap.ArticleCategories.Add(category);
                }

                _service.Create(articleMap);

                return RedirectToAction("Index");
            }

            var resultAuthors = _authorService.GetAuthors().ToList();
            var resultCategories = _categoryService.GetCategories().ToList();
            SelectList authors = new SelectList(resultAuthors, "Id", "Name");
            SelectList categories = new SelectList(resultCategories, "Id", "Title");
            article = new ArticleCreateView { Authors = authors, Categories = categories };

            return View(article);
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
        public ActionResult Edit(ArticleEditorView article)
        {
            // TODO: Add update logic here

            if (string.IsNullOrEmpty(article.Title))
            {
                ModelState.AddModelError("Title", "Required field");
            }

            if (string.IsNullOrEmpty(article.Txt))
            {
                ModelState.AddModelError("Txt", "Required field");
            }


            if (article.UploadImg != null)
            {
                if (article.UploadImg.ContentType == "image/jpeg")
                {

                    string fileName = System.IO.Path.GetFileName(article.UploadImg.FileName);

                    article.UploadImg.SaveAs(Server.MapPath($"~/Resourses/{fileName}"));
                    article.Img = $"~/Resourses/{fileName}";
                }
                else
                {
                    ModelState.AddModelError("UploadImg", "incorrect image format");
                }
            }


            if (article.UploadBook != null)
            {
                if (article.UploadBook.ContentType == "application/pdf")
                {

                    string fileName = System.IO.Path.GetFileName(article.UploadBook.FileName);

                    article.UploadBook.SaveAs(Server.MapPath("~/Books/" + fileName));
                    article.Book = @"Books\" + fileName;
                }
                else
                {
                    ModelState.AddModelError("UploadBook", "incorrect book format (pdf only)");
                }
            }


            if (ModelState.IsValid)
            {
                var articleMod = _mapper.Map<ArticleModel>(article);
                articleMod.DatePost = DateTime.Now;

                _service.Edite(articleMod);

                return RedirectToAction("Index");
            }

            var result = _authorService.GetAuthors().ToList();
            SelectList authors = new SelectList(result, "Id", "Name");
            article.Authors = authors;
            return View(article);
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
            var article = _service.GetById(id);
            var pathImg = Server.MapPath(article.Img);
            var pathBook = Server.MapPath($@"..\{article.Book}");

            if (System.IO.File.Exists(pathImg))
            {
                System.IO.File.Delete(pathImg);
            }

            if (System.IO.File.Exists(pathBook))
            {
                System.IO.File.Delete(pathBook);
            }

            _service.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
