using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.DAO
{
    public class UserDAO
    {
        OnlineShopDbContext db = null;

        public UserDAO()
        {
            db = new OnlineShopDbContext();
        }

        /// <summary>
        /// hàm insert 1 user vào database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }


        public User GetUserByUserName(string Username)
        {
            return db.Users.SingleOrDefault(x=>x.Username == Username);
        }

        /// <summary>
        /// hàm login kiểm tra xem trong db có user và password tương ứng hay không.
        /// dùng linq
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string userName, string password)
        {
            var result = db.Users.Count(x => x.Username == userName && x.Password == password);
            return result > 0;
        }

    }
}
