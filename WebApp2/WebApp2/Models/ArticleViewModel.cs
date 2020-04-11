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
        [Required(ErrorMessage = "Идентификатор пользователя не установлен")]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Идентификатор пользователя не установлен")]
        public string Title { get; set; }
        public string Txt { get; set; }
        public string Img { get; set; }
        //public int Author_Id { get; set; }
    }
}