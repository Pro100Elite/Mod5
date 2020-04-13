using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class MyContextInitializer : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext db)
        {
            Author au1 = new Author { Name = "DjonSeed", Birthday = new DateTime(2015, 7, 20) };
            Author au2 = new Author { Name = "KateSeed", Birthday = new DateTime(1995, 10, 15) };

            Article ar1 = new Article { Img = "~/Resourses/d.jpg", Title = "Seed1", Txt = "AOE BRATAN", Author = au1 };
            Article ar2 = new Article { Img = "~/Resourses/g.jpg", Title = "Seed2", Txt = "AOE BRATAN", Author = au2 };
            Article ar3 = new Article { Img = "~/Resourses/d.jpg", Title = "Seed3", Txt = "AOE BRATAN", Author = au2 };
            Article ar4 = new Article { Img = "~/Resourses/g.jpg", Title = "Seed4", Txt = "AOE BRATAN", Author = au2 };

            //знаю можно циклом 
            au1.Articles.Add(ar1);
            au2.Articles.Add(ar2);
            au2.Articles.Add(ar3);
            au2.Articles.Add(ar4);

            db.Authors.Add(au1);
            db.Authors.Add(au2);
            db.Articles.Add(ar1);
            db.Articles.Add(ar2);
            db.Articles.Add(ar3);
            db.Articles.Add(ar4);
            db.SaveChanges();
        }
    }
}
