using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalForReading.Models
{
    public class ArticleBookView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BookTxt { get; set; }
        public List<string> BookPagin { get; set; }
        public int pageSize = 200;
        public int pagenumber { get; set; }
    }
}