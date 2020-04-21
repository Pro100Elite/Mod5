using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MyContext : DbContext, IMyContext
    {
        public MyContext() : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=BooksPortalDb;Integrated Security=True")
        {
            Database.SetInitializer<MyContext>(new MyContextInitializer());
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasOptional<Author>(s => s.Author)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}
