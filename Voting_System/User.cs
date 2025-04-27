using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting_System
{
    public abstract class User
    {
        private string UserPassWord;
        private string UserName;
        

        public User(string userName, string userPassword)
        {
            UserName = userName;
            UserPassWord = userPassword;
            
        }

        public string GetUserName() => UserName;
        public string GetPassword() => UserPassWord;


        public bool Login(string name, string password)
        {
            if (UserName == name && UserPassWord == password)
            {
                return true;
            }
            return false;
        }

        public void Logout()
        {
            Console.WriteLine($"{UserName} has logged out");
        }

        public abstract void AccessPortal();
        
         
    }
}
