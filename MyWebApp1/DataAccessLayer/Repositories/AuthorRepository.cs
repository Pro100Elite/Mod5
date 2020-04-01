//using DataAccessLayer.Interfaces;
//using DataAccessLayer.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataAccessLayer.Repositories
//{
//    public class AuthorRepository: IAuthorRepository
//    {
//        public IEnumerable<Author>GetAuthors()
//        {
//            using (var _ctx = new MyContext())
//            {
//                var result = _ctx.Authors.ToList();
//                return result;
//            }
//        }
//    }
//}
