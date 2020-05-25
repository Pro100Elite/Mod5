using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalForReading.Models
{
    public class ArticleView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения!")]
        public string Title { get; set; }
        public string Txt { get; set; }
        public string Book { get; set; }
        public string Img { get; set; }
        public DateTime DatePost { get; set; }

        public AuthorView Author { get; set; }

        public ICollection<CategoryView> Categories { get; set; }
    }
}