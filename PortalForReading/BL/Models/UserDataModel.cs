using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class UserDataModel
    {
        public Dictionary<int, int> BooksPage { get; set; }
        public string AccountId { get; set; }
    }
}
