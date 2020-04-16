using ApiWebAppl2.Models;
using AutoMapper;
using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiWebAppl2.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly IArticleService _service;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: api/Article
        public IEnumerable<ArticleApi> Get()
        {
            return _mapper.Map<List<ArticleApi>>(_service.GetArticles());
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
