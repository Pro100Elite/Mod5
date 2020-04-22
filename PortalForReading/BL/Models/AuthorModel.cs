using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public DateTime Birthday { get; set; }
        public string Photo { get; set; }

        public ICollection<ArticleModel> Articles { get; set; }
    }
}
