using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresStore.Repository.Interfaces;
using TyresStore.Repository.Models;
using System.Security.Cryptography;

namespace TyresStore.Repository
{
    public class UserRepository : IUserRepository
    {
        TyresStoreContext tyresContext = new TyresStoreContext();

        //get ID of User with Username and Password
        public bool CheckLogin(int userId)
        {
            User user = new User();
            user = tyresContext.Users.FirstOrDefault(x => x.ID == userId);

            // check datetime
            DateTime expire_login = DateTime.Now;
            if(user.ExpireLogin <= expire_login)
            {
                return false;
            }
            return true;
        }

        //login user
        public bool Login(string username, string password)
        {
            // get user
            User user = new User();
            user = tyresContext.Users.FirstOrDefault(x => x.Username == username);

            // check md5 hashes NICE TO HAVE
            if (password != user.Password)
            {
                return false;
            }

            // set expire datetime now date + 2 hours
            DateTime expire_login = DateTime.Now.AddHours(2.0);
            user.ExpireLogin = expire_login;

            tyresContext.SaveChanges();
            // return true on succes
            return true;
        }

        //logout user
        public void Logout(int userId)
        {
            User user = new User();
            user = tyresContext.Users.FirstOrDefault(x => x.ID == userId);
            // set expire now
            user.ExpireLogin = DateTime.Now;
            tyresContext.SaveChanges();
        }
    }
}
