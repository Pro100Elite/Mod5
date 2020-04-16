using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWebAppl2.Models
{
    public class AuthorApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Photo { get; set; }

        public ICollection<ArticleApi> Articles { get; set; }
    }
}