using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Dummy
{
    class CountryDao : ICountryDao
    {
        public DaoResponse<Country> GetByCode(string code)
        {
            throw new NotImplementedException();
        }
        
        [DaoExceptionHandler(typeof(IList<Country>))]
        public DaoResponse<IList<Country>> GetAll()
        {
            throw new NotSupportedException("Test exception for DaoExceptionHandlerAtrribute test!");
        }
        
        public DaoResponse<IList<Country>> GetAllAndFilterBy<T>(T criteria, Filter<Country, T> filter)
        {
            throw new NotImplementedException();
        }
    }
}
