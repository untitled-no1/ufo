using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.BLL;
using UFO.Server.BLL.Common;
using UFO.Server.BLL.Impl;

namespace UFO.Commander.Util
{
    public static class Session
    {
        public static IAuthentification Authentification;

        public static IGetData GetData;

        public static IModifyData ModifyData;

        public static void InitSession(IAuthentification a)
        {
            Session.Authentification = a;
            Session.GetData = BusinessLayerFactory.CreateGetDataInstance(Authentification);
            Session.ModifyData = BusinessLayerFactory.CreateModifyDataInstance(Authentification);
        }
    }
}
