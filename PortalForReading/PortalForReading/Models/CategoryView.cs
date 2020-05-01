using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalForReading.Models
{
    public class CategoryView
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<ArticleView> Articles { get; set; }
    }
}