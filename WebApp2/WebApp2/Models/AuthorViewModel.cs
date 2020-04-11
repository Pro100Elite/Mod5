using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp2.Models
{
    public class AuthorViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения!")]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Некорректное имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения!")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public ICollection<ArticleViewModel> Articles { get; set; }
    }
}