using DAL.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    public interface IMyContext: IDisposable
    {
        DbSet<Article> Articles { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbEntityEntry Entry(object entity);
        int SaveChanges();
    }
}