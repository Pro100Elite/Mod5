using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp2.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения!")]
        public string Title { get; set; }

        public string Txt { get; set; }
        public string Img { get; set; }

        public AuthorViewModel Author { get; set; }
    }
}