﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalForReading.Models
{
    public class ArticleCreateView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Txt { get; set; }
        public string Book { get; set; }    
        public string Img { get; set; }
        public DateTime DatePost { get; set; }
        public int AuthorId { get; set; }

        public ICollection<int> CategoryId { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public HttpPostedFileBase UploadImg { get; set; }

        public HttpPostedFileBase UploadBook { get; set; }
    }
}