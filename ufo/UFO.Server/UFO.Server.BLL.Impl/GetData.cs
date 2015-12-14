using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<User> GetAllUsers()
        {
            // TODO Authentification
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
