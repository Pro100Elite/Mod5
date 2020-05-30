using System;
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

        [Required(ErrorMessage = "Required!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string Txt { get; set; }
        public string Book { get; set; }

     
        public string Img { get; set; }

        public DateTime DatePost { get; set; }

        public int AuthorId { get; set; }

        public ICollection<int> CategoryId { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [Remote("ValidatorImg", "Article", ErrorMessage = "IMG SUKA")]
        public HttpPostedFileBase UploadImg { get; set; }

        [Remote("ValidatorPdf", "Article", ErrorMessage = "PDF SUKA")]
        public HttpPostedFileBase UploadBook { get; set; }
    }
}