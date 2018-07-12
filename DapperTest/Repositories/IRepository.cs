using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IEnumerable<TEntity> Find(object entity);

        IEnumerable<TEntity> Get();

        int Add(TEntity entity);

        int AddRange(IEnumerable<TEntity> entities);

        int Remove(TEntity entity);

        int RemoveRange(IEnumerable<TEntity> entities);
    }
}
