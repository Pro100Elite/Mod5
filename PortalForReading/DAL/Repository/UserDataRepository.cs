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
    public class UserDataRepository: IUserDataRepository
    {
        private readonly IMyContext _ctx;

        public UserDataRepository(IMyContext context)
        {
            _ctx = context;
        }

        public void Create(UserData userData)
        {
            using (_ctx)
            {
                _ctx.UserData.Add(userData);

                _ctx.SaveChanges();
            }
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
            using (_ctx)
            {
                _ctx.Entry(userData).State = EntityState.Modified;

                _ctx.SaveChanges();
            }
        }
    }
}
