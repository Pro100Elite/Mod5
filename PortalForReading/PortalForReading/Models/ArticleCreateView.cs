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

        //[Remote("ValidatorImg", "Article", ErrorMessage = "IMG")]
        [Required(ErrorMessage = "Please select file.")]
        //[RegularExpression(@"(^[А-Яа-яa-zA-Z0-9\s_\\.\-:–])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        //[FileExtensions(Extensions = ("png|jpg|gif"), ErrorMessage = "Only Img files allowed.")]
        public HttpPostedFileBase UploadImg { get; set; }

        //[Remote("ValidatorPdf", "Article", ErrorMessage = "PDF")]
        [Required(ErrorMessage = "Please select file.")]
        //[RegularExpression(@"([А-Яа-яa-zA-Z0-9\s_\\.\-:–])+(.pdf)$", ErrorMessage = "Only Pdf files allowed.")]
        //[FileExtensions(Extensions = ("pdf"), ErrorMessage = "Only Pdf files allowed.")]
        public HttpPostedFileBase UploadBook { get; set; }
    }
}