using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp2.WebApi.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Txt { get; set; }
        public string Img { get; set; }
    }
}