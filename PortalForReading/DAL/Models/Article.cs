using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Txt { get; set; }
        public string Book { get; set; }
        public string Img { get; set; }
        public DateTime DatePost { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        //[ForeignKey("Categories")]
        //public int CategoryId { get; set; }

        public virtual ICollection<CategoryArticle> ArticleCategories { get; set; }
    }
}
