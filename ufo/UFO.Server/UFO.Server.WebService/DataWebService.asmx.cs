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
        private IGetData getDataProxy;

        public DataWebService()
        {
            getDataProxy = BusinessLayerFactory.CreateGetDataInstanceWeb();
        }

        [WebMethod]
        public User LogIn(string user, string passwordHash)
        {
            return getDataProxy.VerifyUser(user, passwordHash);
        }


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public Artist GetArtistByName(string name)
        {
            return getDataProxy.GetArtistByName(name);
        }

        [WebMethod]
        public Artist GetArtistById(int id)
        {
            return getDataProxy.GetArtistById(id);
        }

        [WebMethod]
        public List<Artist> GetArtistsPage(Page ArtistPage)
        {
            var tmp = getDataProxy.GetArtistsPage(ArtistPage);
            return tmp;
        }

        [WebMethod]
        public Venue GetVenueById(string id)
        {
            return getDataProxy.GetVenueById(id);
        }

        [WebMethod]
        public List<Venue> GetVenuesPage(Page VenuePage)
        {
            return getDataProxy.GetVenuesPage(VenuePage);
        }

        [WebMethod]
        public List<Performance> GetPerformancesPage(Page PerformancePage)
        {
            var result = getDataProxy.GetPerformancePage(PerformancePage);
            return result;
        }

        [WebMethod]
        public List<string> GetAllPerformanceDates()
        {
            var performances = getDataProxy.GetAllPerformances();
            List<string> dates = new List<string>();
            foreach (var s in performances)
            {
                var date = s.DateTime.Date.ToString("yyyy-MM-dd");
                if (!dates.Contains(date))
                    dates.Add(date);
            }
            return dates;
        }

        [WebMethod]
        public List<Performance> getPerformancesPerArtist(int id)
        {
            return getDataProxy.GetPerformancesPerArtist(id);
        }

        [WebMethod]
        public List<Performance> getPerformancesPerVenue(string id)
        {
            return getDataProxy.GetPerformancesPerVenue(id);
        }

        [WebMethod]
        public List<Performance> GetPerformancesPerDate(DateTime d)
        {
            return getDataProxy.GetPerformancesPerDate(d);
        }

        [WebMethod]
        public bool deletePerformance(User u, Performance p)
        {
            var auth = BusinessLayerFactory.CreateAuthentificationInstance(u.EMail, u.Password);
            var modifyData = BusinessLayerFactory.CreateModifyDataInstance(auth);
            var res = modifyData.DeletePerformance(p);
            return res;
        }

        [WebMethod]
        public bool UpdatePerformance(User u, Performance oldPerformance, Performance newPerformance)
        {
            var auth = BusinessLayerFactory.CreateAuthentificationInstance(u.EMail, u.Password);
            var modifyData = BusinessLayerFactory.CreateModifyDataInstance(auth);
            var result = modifyData.ModifyPerformance(oldPerformance, newPerformance);
            return result;
        }
    }
}
