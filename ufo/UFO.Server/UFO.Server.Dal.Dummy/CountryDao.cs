using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public DaoResponse<Country> Insert(Country entity)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Country> Update(Country entity)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Country> Delete(Country entity)
        {
            throw new NotImplementedException();
        }

        [DaoExceptionHandler(typeof(IList<Country>))]
        public DaoResponse<IList<Country>> SelectAll()
        {
            throw new NotSupportedException("Test exception for DaoExceptionHandlerAtrribute test!");
        }
        
        public DaoResponse<IList<Country>> SelectWhere<T>(Expression<Filter<Country, T>> filterExpression, T criteria)
        {
            throw new NotImplementedException();
        }
    }
}
