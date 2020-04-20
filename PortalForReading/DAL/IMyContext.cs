using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IMyContext : IDisposable
    {
        DbSet<Article> Articles { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Category> Categories { get; set; }
        DbEntityEntry Entry(object entity);
        int SaveChanges();
    }
}
