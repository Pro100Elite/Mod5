using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserDataRepository : IUserDataRepository, IDisposable
    {
        private readonly IMyContext _ctx;

        public UserDataRepository(IMyContext context)
        {
            _ctx = context;
        }

        public UserData GetById(string accountId, int bookId)
        {
            return _ctx.UserData.AsNoTracking().FirstOrDefault(u => u.AccountId == accountId & u.BookId == bookId);
        }

        public void Create(UserData userData)
        {
            _ctx.UserData.Add(userData);

            _ctx.SaveChanges();
        }

        //public void Delete(int id)
        //{
        //    using (_ctx)
        //    {
        //        _ctx.Articles.Remove(GetById(id));

        //        _ctx.SaveChanges();
        //    }
        //}

        public void Update(UserData userData)
        {
            var bookPage = _ctx.UserData.FirstOrDefault(x => x.AccountId == userData.AccountId && x.BookId == userData.BookId);

            if (bookPage is null)
            {
                _ctx.UserData.Add(userData);
                _ctx.SaveChanges();
                bookPage = _ctx.UserData.FirstOrDefault(x => x.AccountId == userData.AccountId && x.BookId == userData.BookId);
            }

            bookPage.BookPage = userData.BookPage;

            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
