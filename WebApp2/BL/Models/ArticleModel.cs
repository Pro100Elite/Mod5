using System;
using System.Collections.Generic;
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
        public string Img { get; set; }
        //public int Author_Id { get; set; }
    }
}
