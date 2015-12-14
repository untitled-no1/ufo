using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var daoFacotry = DalProviderFactories.GetDaoFactory();
            var artistDao = daoFacotry.CreateArtistDao();
            artistDao.Update(new Artist())
                .OnSuccess(artist => Console.WriteLine($"Found artist id: {artist.ArtistId}"))
                .OnFailure(response => Console.WriteLine($"Error: {response.ErrorMessage}; {response.Exception}"));

            artistDao.SelectAll()
                .OnSuccess(list =>
                {
                    foreach (var artist in list)
                    {
                        Console.WriteLine($"{artist}");
                    }
                })
                .OnFailure(response => Console.WriteLine($"Error: {response.ErrorMessage}"));

            var userDao = daoFacotry.CreateUserDao();
            userDao.SelectWhere<IList<User>>((list, value) => list.Where(x => x.IsArtist))
                .OnSuccess(users =>
                {
                    foreach (var user in users)
                    {
                        Console.WriteLine($"Update user: ({user}) successful");
                    }
                })
                .OnFailure(response => { throw response.Exception; });

            var performanceDao = daoFacotry.CreatePerformanceDao();
            performanceDao.SelectById(new DateTime(2015, 11, 15, 22, 00, 00), 64)
                .OnSuccess(response => Console.WriteLine($"{response.ResultObject}"))
                .OnEmptyResult(() => Console.WriteLine("No performance data found!"))
                .OnFailure(response => Console.WriteLine($"{response.Exception}"));

            Console.ReadLine();
        }
    }
}
