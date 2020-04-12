using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;

namespace DAL
{
    public class MyContext: DbContext, IMyContext
    {
        public MyContext() : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=WebDB;Integrated Security=True")
        {
            Database.SetInitializer<MyContext>(new MyContextInitializer());
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
