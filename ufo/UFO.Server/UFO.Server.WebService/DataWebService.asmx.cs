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
        private Page ArtistPage;

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
        public List<Artist> GetNextArtistsPage()
        {
            if(ArtistPage == null)
                ArtistPage = new Page();
            else
                ArtistPage.next();
            return dataProxy.GetArtistsPage(ArtistPage);
        } 
    }
}
