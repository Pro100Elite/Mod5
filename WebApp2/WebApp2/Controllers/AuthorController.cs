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
    public class AuthorController : Controller
    {
        private readonly IAuthorService _service;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _service = authorService;
            _mapper = mapper;
        }

        // GET: Author
        public ActionResult Index()
        {
            var authors = _mapper.Map<List<AuthorViewModel>>(_service.GetAuthors());

            ViewBag.Message = "Authors";
            return View(authors);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            var author = _mapper.Map<AuthorViewModel>(_service.GetAuthors().FirstOrDefault(x => x.Id == id));

            ViewBag.Message = "Author";
            return View(author);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(AuthorViewModel author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }
            var resultMap = _mapper.Map<AuthorModel>(author);
            _service.Create(resultMap);
            return RedirectToAction("Index");
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            return RedirectToAction("Index");
        }

        // GET: Author/Delete/5
        //[HttpGet]
        public ActionResult Delete()
        {
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
