using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalForReading.Models
{
    public class AuthorView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required!")]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Invalid name")]
        public string Name { get; set; }

        public string Photo { get; set; }
    }
}