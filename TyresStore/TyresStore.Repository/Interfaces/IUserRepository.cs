using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresStore.Repository.Models;

namespace TyresStore.Repository.Interfaces
{
    public interface IUserRepository
    {

        bool CheckLogin(int userId);
        bool Login(string username, string password);
        void Logout(int userId);
    }
}
