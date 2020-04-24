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
            Author au1 = new Author { Name = "Хаяо Миядзаки", Photo = "~/Resourses/Anonim.png" };
            Author au2 = new Author { Name = "KateSeed"};

            Article ar1 = new Article { Img = "~/Resourses/Monarch.jpg", 
                Title = "Монарх Вечной Ночи", 
                Txt = @"Монарх Вечной Ночи – это фэнтези новелла в сеттинге, напоминающем стимпанк. В ней имеются также элементы западного фэнтези – вампиры, оборотни и арахниды. Это тёмная и взрослая новелла, включающая в себя замысловатый сюжет, сосредоточенный вокруг крупномасштабных войн и политики. Она значительно отличается от традиционных wuxia-новелл тем, что имеет быстрое развитие сюжета, частый экшен и практически нулевое количество филлеров.
История начинается на свалке континента Вечной Ночи вместе с нашим протагонистом, брошенным ребенком, и следует за главным героем, когда он выживает в жестоком, со спартанскими условиями, военном лагере, и в конечном итоге получает своё место в качестве гордой элиты войск Империи. Но потом с ним случится нечто, что навсегда изменит его жизнь и поставит под сомнение все его убеждения, заставив по-новому посмотреть на то, что его раньше учили ненавидеть. Несовершенный человек, мы будем следовать за ним по мере того, как он становится сильнее и как боец, и как личность, обретая новых союзников и врагов на своем пути. Но куда приведет его эта тропа – это мы узнаем в процессе. 
История начинается фактически со второго тома, и в последствии продолжает увеличивать темп. Первый том – это по сути долгий пролог", 
                Book = @"I:\project\Mod5\PortalForReading\PortalForReading\Books\Монарх_Вечной_Ночи_Том_1_Глава_1_–_Кровавая_ночь_-_Том_3_Глава_120_–_Расставание_(2).fb2", 
                Author = au1 };
            Article ar2 = new Article { Img = "~/Resourses/Anonim.jpg",
                Title = "Seed2",
                Txt = "AOE BRATAN",
                Book = @"I:\project\Mod5\PortalForReading\PortalForReading\Books\Метцен К., Брукс Р., Бернс М. - Варкрафт. Хроники. Энциклопедия - 2016.fb2",
                Author = au2 };
            Article ar3 = new Article { Img = "~/Resourses/Anonim.jpg", Title = "Seed3", Txt = "AOE BRATAN", Author = au2 };
            Article ar4 = new Article { Img = "~/Resourses/Anonim.jpg", Title = "Seed4", Txt = "AOE BRATAN", Author = au2 };

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
