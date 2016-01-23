using System.Security.Authentication;
using UFO.Server.BLL.Common;
using UFO.Server.BLL.Impl;
using UFO.Server.Domain;

namespace UFO.Server.BLL
{
    public static class BusinessLayerFactory
    {

        public static IGetData CreateGetDataInstanceWeb()
        {
            return new GetData();
        }

        public static IGetData CreateGetDataInstance(IAuthentification auth)
        {
            if(auth == null)
                throw new AuthenticationException();
            return new GetData(auth);
        }

        public static IModifyData CreateModifyDataInstance(IAuthentification auth)
        {
            if (auth == null)
                throw new AuthenticationException();
            return new ModifyData(auth);
        }

        public static IAuthentification CreateAuthentificationInstance(string name, string hash)
        {
            User u = new User();
            u.EMail = name;
            u.Password = hash;
            return new Authentification(u);
        }

    }
}
