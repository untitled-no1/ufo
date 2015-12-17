using System.Security.Authentication;
using UFO.Server.BLL.Common;
using UFO.Server.BLL.Impl;
using UFO.Server.Domain;

namespace UFO.Server.BLL
{
    public static class BusinessLayerFactory
    {

        public static IGetData CreateGetDataInstance(IAuthentification auth)
        {
            if(auth == null)
                throw new AuthenticationException();
            return new GetData(auth);
        }

        public static IAuthentification CreateAuthentificationInstance(User user)
        {
            return new Authentification(user);
        }

    }
}
