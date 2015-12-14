

using UFO.Server.Domain;

namespace UFO.Server.BLL.Common
{
    public interface IAuthentification
    {
        bool Login(string email, string hash);
        bool Logout();
        bool IsLoggedIn();
        User GetLoggedUser();
    }
}
