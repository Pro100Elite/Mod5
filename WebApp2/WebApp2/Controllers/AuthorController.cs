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

        public AuthorController()
        {
            _service = new AuthorService();
        }

        // GET: Author
        public ActionResult Index()
        {
            var config = new MapperConfiguration(con =>
            {
                con.CreateMap<AuthorModel, AuthorViewModel>();
                con.CreateMap<ArticleModel, ArticleViewModel>();
            });

            var mapper = new Mapper(config);

            var authors = mapper.Map<List<AuthorViewModel>>(_service.GetAuthors());

            ViewBag.Message = "Authors";
            return View(authors);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            var config = new MapperConfiguration(con => 
            {
                con.CreateMap<AuthorModel, AuthorViewModel>();
                con.CreateMap<ArticleModel, ArticleViewModel>();
            });

            var mapper = new Mapper(config);

            var author = mapper.Map<AuthorViewModel>(_service.GetAuthors().FirstOrDefault(x => x.Id == id));

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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var config = new MapperConfiguration(con =>
                {
                    con.CreateMap<FormCollection,AuthorModel>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src["name"])); 
                });

                var mapper = new Mapper(config);

                var author = mapper.Map<AuthorModel>(collection);
                _service.Create(author);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Author/Delete/5
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
