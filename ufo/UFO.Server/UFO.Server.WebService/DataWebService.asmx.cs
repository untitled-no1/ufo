using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UFO.Server.BLL;
using UFO.Server.BLL.Common;
using UFO.Server.BLL.Impl;
using UFO.Server.Domain;

namespace UFO.Server.WebService
{
    /// <summary>
    /// Summary description for DataWebService
    /// </summary>
    [WebService(Namespace = "http://ufo.untitled-no1.at/webservice/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DataWebService : System.Web.Services.WebService
    {
        private IGetData dataProxy;

        public DataWebService()
        {
            IAuthentification auth = BusinessLayerFactory.CreateAuthentificationInstance("a@a.com", "0cc175b9c0f1b6a831c399e269772661");
            dataProxy = BusinessLayerFactory.CreateGetDataInstance(auth);
        }


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public Artist GetArtistByName(string name)
        {
            return dataProxy.GetArtistByName(name);
        }

        [WebMethod]
        public Artist GetArtistById(int id)
        {
            return dataProxy.GetArtistById(id);
        }

        [WebMethod]
        public List<Artist> GetArtistsPage(Page ArtistPage)
        {
            var tmp = dataProxy.GetArtistsPage(ArtistPage);
            return tmp;
        }

        [WebMethod]
        public Venue GetVenueById(string id)
        {
            return dataProxy.GetVenueById(id);
        }

        [WebMethod]
        public List<Venue> GetVenuesPage(Page VenuePage)
        {
            return dataProxy.GetVenuesPage(VenuePage);
        }

        [WebMethod]
        public List<Performance> GetPerformancesPage(Page PerformancePage)
        {
            return dataProxy.GetPerformancePage(PerformancePage);
        }

        [WebMethod]
        public List<string> GetAllPerformanceDates()
        {
            var performances = dataProxy.GetAllPerformances();
            List<string> dates = new List<string>();
            foreach (var s in performances)
            {
                var date = s.DateTime.Date.ToString("yyyy-MM-dd");
                if (!dates.Contains(date))
                    dates.Add(date);
            }
            return dates;
        } 
    }
}
