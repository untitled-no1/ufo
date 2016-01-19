using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UFO.Server.BLL;
using UFO.Server.BLL.Common;
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

        //private IGetData dataProxy = BusinessLayerFactory.CreateGetDataInstance();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public Artist GetArtistByName(string name)
        {
            //return dataProxy.GetArtistByName("");
            return new Artist();
        }
    }
}
