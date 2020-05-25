using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Txt { get; set; }
        public string Book { get; set; }
        public string Img { get; set; }

        public int AuthorId { get; set; }

        public AuthorModel Author { get; set; }

        public ICollection<CategoryArticleModel> ArticleCategories { get; set; }
    }
}
