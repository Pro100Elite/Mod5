﻿using DAL.Models;
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
            Author au1 = new Author { Name = "Хаяо Миядзаки", Photo = "~/Resourses/Author1.png" };
            Author au2 = new Author { Name = "KateSeed"};

            Article ar1 = new Article { Img = "~/Resourses/d.jpg", Title = "Унесённые призраками", Txt = @"Отец Акио, мать Юко и их десятилетняя дочь Тихиро переезжают в новый дом, расположенный где-то в глубинке Японии. Перепутав дорогу к новому дому и проехав через странный лес, они попадают в тупик: останавливаются перед высокой стеной, в которой темнеет вход. Войдя туда и проследовав по длинному тёмному туннелю, они попадают в здание, похожее на вокзал, выйдя из которого, оказываются в пустующем городке, почти полностью состоящем из пустующих ресторанов. Нигде нет ни души, но по приятному запаху отец находит пустой, но явно действующий ресторанчик, в котором обнаруживается стол, ломящийся от деликатесов и самых различных яств. Отец с матерью остаются перекусить, а Тихиро отправляется бродить по городу. Выйдя к большому зданию с надписью «Купальни Абура-я», она встречает мальчика Хаку, который требует, чтобы она немедленно бежала отсюда. Быстро сгущаются сумерки и наступает вечер, город наводняют странные тени, появляющиеся отовсюду. Тихиро бросается к ресторану, где остались её родители, и с ужасом обнаруживает, что они превратились в свиней. Перепуганная Тихиро бежит к тому месту, откуда они пришли, однако теперь на пути не пройденное ранее сухое каменистое русло, а широкая река. 
Хаку находит Тихиро и помогает ей: проводит к зданию купален и объясняет происходящее. Оказывается, Тихиро с родителями попали в волшебный мир. Хозяйка городка — колдунья Юбаба, под её управлением находятся купальни и рестораны, куда приезжают отдыхать боги, призраки, духи и другие сверхъестественные существа со всего света. Всех, кроме гостей и своих работников, Юбаба превращает в животных. Чтобы получить надежду на спасение родителей и возвращение домой, Тихиро, по совету Хаку, должна потребовать у Юбабы работу — согласно давнему зароку, Юбаба не может никому отказать в такой просьбе. При помощи новых знакомых — деда Камадзи и банщицы Рин — Тихиро удаётся добраться до кабинета Юбабы и получить там работу, а вместе с ней — новое имя. Теперь Тихиро зовут Сэн. 
Тихиро начинает работать в купальнях, она очень старается, надеясь помочь родителям вернуть человеческий облик и найти путь назад. Однажды в отсутствие Юбабы Тихиро становится свидетельницей того, как Хаку возвращается откуда-то в облике дракона, преследуемый стаей бумажных птичек. Пробравшись за Хаку в покои Юбабы, Тихиро узнаёт, что Хаку по приказу Юбабы украл у её сестры-близнеца Дзенибы заколдованную печать и теперь умирает от наложенного на печать проклятия. С помощью деда Камадзи и «горького пирожка», подаренного ранее клиентом — духом рек, — Тихиро уничтожает проклятие и таким образом спасает Хаку от смерти. После этого она решает отправиться к Дзенибе, чтобы вернуть украденную печать и попросить простить и вылечить Хаку. Тихиро предпринимает путешествие на поезде в компании Безликого призрака-бога, которого накануне сама пустила в купальни, а также превращённых Дзенибой в мелкого зверька и маленькую птичку сына Юбабы Бо и птицы-соглядатая. В это же время пришедший в себя Хаку заставляет Юбабу пообещать дать Тихиро шанс расколдовать родителей и вернуться в свой мир, если сам он вернёт Юбабе сына. Хаку отправляется за Тихиро и сыном Юбабы к Дзенибе. Дзениба прощает Хаку. Тихиро, Хаку, Бо и птица-соглядатай вместе возвращаются в купальни к Юбабе. Во время обратного путешествия Тихиро помогает Хаку вспомнить его настоящее имя. Вернув свои воспоминания, Хаку освобождает себя от обязанности служить Юбабе. 
Вернувшись в купальни, Тихиро проходит последнее испытание — ей нужно узнать своих родителей среди свиней. Тихиро отвечает верно, что среди них нет её родителей. После чего договор, подписанный Тихиро с Юбабой, исчезает. Юбаба отпускает девочку. Хаку провожает Тихиро и предупреждает её ни в коем случае не оглядываться. При прощании он говорит, что закончит свои дела и вернётся в реальный мир, где они обязательно встретятся. 
Вернувшись назад к странному зданию, похожему на вокзал, Тихиро встречает отца и мать, не помнящих ничего о произошедшем и уверенных, что они просто прогулялись. Вся семья опять идёт по туннелю и выходит назад к автомобилю, который за время их отсутствия оказывается сильно засыпан опавшей листвой и запылён внутри. Удивившись этому факту, но не придав ему большого значения, они уезжают. ", Author = au1 };
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
