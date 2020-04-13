using AutoMapper;
using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp2.WebApi.Models;

namespace WebApp2.WebApi.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly IArticleService _service;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _service = articleService;
            _mapper = mapper;
        }
        // GET: api/Article
        public IEnumerable<ArticleViewModel> Get()
        {
            return _service.GetArticles();
        }

        // GET: api/Article/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Article
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Article/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Article/5
        public void Delete(int id)
        {
        }
    }
}
