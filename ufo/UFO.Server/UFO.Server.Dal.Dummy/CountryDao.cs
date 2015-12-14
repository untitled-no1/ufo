﻿using System;
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

        [DaoExceptionHandler(typeof(List<Country>))]
        public DaoResponse<List<Country>> SelectAll()
        {
            throw new NotSupportedException("Test exception for DaoExceptionHandlerAtrribute test!");
        }
        
        public DaoResponse<List<Country>> SelectWhere<T>(Expression<Filter<Country, T>> filterExpression, T criteria = default(T))
        {
            throw new NotImplementedException();
        }
    }
}
