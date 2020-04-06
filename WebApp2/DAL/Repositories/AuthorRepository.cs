﻿using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public IEnumerable<Author> GetAuthors()
        {
            using (var _ctx = new MyContext())
            {
                var result = _ctx.Authors.Include(a => a.Articles).ToList();
                return result;
            }
        }

        public void Create(Author author)
        {
            using (var _ctx = new MyContext())
            {
                _ctx.Authors.Add(author);
                _ctx.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (var _ctx = new MyContext())
            {
                var deleteItem = _ctx.Authors.Find(Id);
                _ctx.Authors.Remove(deleteItem);
                _ctx.SaveChanges();
            }
        }
    }
}