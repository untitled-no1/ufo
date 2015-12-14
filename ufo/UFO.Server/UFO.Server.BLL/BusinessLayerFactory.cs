using UFO.Server.BLL.Common;
using UFO.Server.BLL.Impl;

namespace UFO.Server.BLL
{
    public static class BusinessLayerFactory
    {

        public static IGetData CreateGetDataInstance()
        {
            return new GetData();
        }

    }
}
