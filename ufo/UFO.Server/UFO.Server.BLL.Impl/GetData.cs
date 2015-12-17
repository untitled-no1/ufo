using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.BLL;
using UFO.Server.BLL.Common;
using UFO.Server.Dal;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.BLL.Impl
{
    public class GetData : IGetData
    {
        private IUserDao userDao = DalProviderFactories.GetDaoFactory().CreateUserDao();
        private IArtistDao artistDao = DalProviderFactories.GetDaoFactory().CreateArtistDao();
        private IAuthentification authentification;

        public GetData(IAuthentification authentification)
        {
            this.authentification = authentification;
        }

        public List<User> GetAllUsers()
        {
            if (!authentification.IsLoggedIn())
                throw new AuthenticationException();


            return userDao.SelectAll().ResultObject;
        }

        public Artist GetArtistByName(string name)
        {
            return artistDao.SelectByName(name).ResultObject;
        }
        

        public List<Artist> GetAllArtists()
        {
            return artistDao.SelectAll().ResultObject;
        }
    }
}
