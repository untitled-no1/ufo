using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .OnSuccess(artist =>
                {
                    Console.WriteLine($"Found artist id: {artist.ArtistId}");
                })
                .OnFailure(response => Console.WriteLine($"Error: {response.ErrorMessage}; {response.Exception}"));

            artistDao.GetAll()
                .OnSuccess(list =>
                {
                    foreach (var artist in list)
                    {
                        Console.WriteLine($"Artist: {artist}");
                    }
                }).OnFailure(response => Console.WriteLine($"Error: {response.ErrorMessage}"));

            Console.ReadLine();
        }
    }
}
