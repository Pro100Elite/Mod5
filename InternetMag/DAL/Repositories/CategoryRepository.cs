using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository
    {
        public List<Category> categories = new List<Category>();

        public IEnumerable<Category> GetCategories()
        {
            categories.Add(new Category { Id = 0, Name = "All" });
            categories.Add(new Category { Id = 1, Name = "Cetegory1" });
            categories.Add(new Category { Id = 2, Name = "Cetegory2" });
            categories.Add(new Category { Id = 3, Name = "Cetegory3" });
            categories.Add(new Category { Id = 4, Name = "Cetegory4" });

            return categories;
        }
    }
}
