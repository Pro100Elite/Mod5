using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalForReading.Models
{
    public class AuthorView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения!")]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Некорректное имя")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Обязательно для заполнения!")]
        //[DataType(DataType.Date)]
        //public DateTime Birthday { get; set; }

        public string Photo { get; set; }

        public ICollection<ArticleView> Articles { get; set; }
    }
}