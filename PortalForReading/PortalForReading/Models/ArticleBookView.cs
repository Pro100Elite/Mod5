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
        public string Book { get; set; }
        public int pagenumber { get; set; }
    }
}