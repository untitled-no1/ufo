using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.BLL.Common;
using UFO.Server.Dal;
using UFO.Server.Domain;

namespace UFO.Server.BLL.Impl
{
    public class Authentification : IAuthentification
    {
        private User user;
        private bool loggedIn;

        public Authentification(User user)
        {
            bool valid = DalProviderFactories.GetDaoFactory().CreateUserDao().VerifyAdminCredentials(user).ResultObject;
            if (!valid) throw new AuthenticationException();
            this.user = user;
            this.loggedIn = true;
        }

        public void Logout()
        {
            this.user = null;
            this.loggedIn = false;

        }

        public bool IsLoggedIn()
        {
            return loggedIn;
        }

        public User GetLoggedUser()
        {
            return user;
        }
    }
}
