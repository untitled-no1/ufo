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
    class CategoryDao : ICategoryDao
    {
        public DaoResponse<Category> SelectById(string id)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Category> Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Category> Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Category> Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<IList<Category>> SelectAll()
        {
            throw new NotImplementedException();
        }
        
        public DaoResponse<IList<Category>> SelectWhere<T>(Expression<Filter<Category, T>> filterExpression, T criteria)
        {
            throw new NotImplementedException();
        }
    }
}
