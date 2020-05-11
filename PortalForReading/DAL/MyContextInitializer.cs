﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class MyContextInitializer : CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext db)
        {
            Author au1 = new Author { Name = "Хаяо Миядзаки", Photo = "~/Resourses/Anonim.png" };
            Author au2 = new Author { Name = "KateSeed" };

            Category ct1 = new Category { Title = "Fantasy" };
            Category ct2 = new Category { Title = "Vampire" };

            Article ar1 = new Article
            {
                Img = "~/Resourses/Monarch.jpg",
                Title = "Монарх Вечной Ночи",
                Txt = @"Монарх Вечной Ночи – это фэнтези новелла в сеттинге, напоминающем стимпанк. В ней имеются также элементы западного фэнтези – вампиры, оборотни и арахниды. Это тёмная и взрослая новелла, включающая в себя замысловатый сюжет, сосредоточенный вокруг крупномасштабных войн и политики. Она значительно отличается от традиционных wuxia-новелл тем, что имеет быстрое развитие сюжета, частый экшен и практически нулевое количество филлеров.
История начинается на свалке континента Вечной Ночи вместе с нашим протагонистом, брошенным ребенком, и следует за главным героем, когда он выживает в жестоком, со спартанскими условиями, военном лагере, и в конечном итоге получает своё место в качестве гордой элиты войск Империи. Но потом с ним случится нечто, что навсегда изменит его жизнь и поставит под сомнение все его убеждения, заставив по-новому посмотреть на то, что его раньше учили ненавидеть. Несовершенный человек, мы будем следовать за ним по мере того, как он становится сильнее и как боец, и как личность, обретая новых союзников и врагов на своем пути. Но куда приведет его эта тропа – это мы узнаем в процессе. 
История начинается фактически со второго тома, и в последствии продолжает увеличивать темп. Первый том – это по сути долгий пролог",

                Book = @"Books\Монарх_Вечной_Ночи_Том_1_Глава_1_–_Кровавая_ночь.pdf",
                Author = au1
            };

            Article ar2 = new Article
            {
                Img = "~/Resourses/WarcraftTom3.jpg",
                Title = "Варкрафт Хроники. Том 3",
                Txt = @"После первых двух войн между Ордой и Альянсом мир на небольшое время воцарился в Азероте. Но близилась Третья война, события которой хорошо раскрыты в серии игр Warcraft III.
В третий том Хроник вошел большой промежуток событий вселенной,
                начиная от Третьей войны,
                и заканчивая разрушительным Катаклизмом,
                который создал дракон Смертокрыл.В этом томе вы узнаете о первом вторжении Пылающего Легиона в Азерот,
                названного Третьей войной; об Артасе и его становлении Королём-личом; об Иллидане Ярость Бури и Пылающем походе на Запределье; о пробуждении Короля - лича и о войне в Нордсколе; а также о Смертокрыле и о Катаклизме, который он причинил.
По сути, третий том Хроник – это сжатый каноничный пересказ событий «Warcraft III», «WoW: Classic», «WoW: The Burning Crusade», «WoW: Wrath of the Lich King» и «WoW: Cataclysm».",

                Book = @"Books\Warcraft_Hroniki_Tom3.pdf",
                Author = au2
            };

            Article ar3 = new Article
            {
                Img = "~/Resourses/Vedmak2.jpg",
                Title = "Ведьмак -Меч Предназначения",
                Txt = @"Анджей Сапковский — один из тех редких авторов, чьи произведения не просто обрели в нашей стране культовый статус, но стали частью российской фантастики. Более того, Сапковский — писатель, обладающий талантом творить абсолютно оригинальные фэнтези, полностью свободные от влияния извне, однако связанные с классической мифологической традицией.
Книги Сапковского не просто блистательны по литературности формы и глубине содержания.Они являют собою картину мира — мира «меча и магии»,
                мира искрометного юмора,
                не только захватывающего внимание читателя,
                но трогающего его душу.",

                Book = @"Books\Vedmak2.pdf",
                Author = au2
            };

            Article ar4 = new Article { Img = "~/Resourses/Anonim.jpg", Title = "Seed4", Txt = "AOE BRATAN", Author = au2 };

            //знаю можно циклом 
            au1.Articles.Add(ar1);
            au2.Articles.Add(ar2);
            au2.Articles.Add(ar3);
            au2.Articles.Add(ar4);

            ar1.Categories.Add(ct1);
            ar1.Categories.Add(ct2);
            ar2.Categories.Add(ct1);
            ar3.Categories.Add(ct1);
            ar4.Categories.Add(ct1);

            db.Authors.Add(au1);
            db.Authors.Add(au2);

            db.Categories.Add(ct1);
            db.Categories.Add(ct2);

            db.Articles.Add(ar1);
            db.Articles.Add(ar2);
            db.Articles.Add(ar3);
            db.Articles.Add(ar4);

            db.SaveChanges();
        }
    }
}
