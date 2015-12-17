

using UFO.Server.Domain;

namespace UFO.Server.BLL.Common
{
    public interface IAuthentification
    {
        void Logout();
        bool IsLoggedIn();
        User GetLoggedUser();
    }
}
