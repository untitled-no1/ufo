using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.BLL.Common;
using UFO.Server.Dal;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.BLL.Impl
{
    public class Authentification : IAuthentification
    {
        private User user;
        private bool loggedIn;

        public Authentification(User user)
        {
            IUserDao userDao = DalProviderFactories.GetDaoFactory().CreateUserDao();
            DaoResponse<User> response = userDao.SelectByEmail(user.EMail);
            if (response.ResponseStatus == DaoStatus.Successful)
            {
                user.UserId = response.ResultObject.UserId;
                bool valid = userDao.VerifyAdminCredentials(user).ResultObject;
                if (!valid)
                {
                    this.loggedIn = false;
                }
                else
                {
                    this.user = response.ResultObject;
                    this.loggedIn = true;
                }
            }
            else
            {
                this.loggedIn = false;
            }
            
            
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
