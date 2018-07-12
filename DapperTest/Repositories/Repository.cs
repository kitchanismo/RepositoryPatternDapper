using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Collections;
using MicroOrm.Pocos.SqlGenerator;
using DapperTest.Models;

namespace DapperTest
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        public Repository(IDbConnection connection, ISqlGenerator<TEntity> sqlGenerator)
        {
            Generator = sqlGenerator;
            Connection = connection;
        }
        
        protected readonly IDbConnection Connection;
        protected readonly ISqlGenerator<TEntity> Generator;

        public IEnumerable<TEntity> Get()
        {
            return Connection.Query<TEntity>(Generator.GetSelectAll()).ToList();
        }

        public IEnumerable<TEntity> Find(object entity)
        {
            return Connection.Query<TEntity>(Generator.GetSelect(entity), entity);
        }
        
        public int Add(TEntity entity)
        {
            return Connection.Query(Generator.GetInsert(), entity).Count();
        }

        public int AddRange(IEnumerable<TEntity> entities)
        {
            int count = 0;
            foreach (var entity in entities)
            {
                Add(entity);
                count++;
            }
            return count;
        }
        
        public int Remove(TEntity entity)
        {
            return Connection.Query<TEntity>(Generator.GetDelete(), entity).Count();
        }

        public int RemoveRange(IEnumerable<TEntity> entities)
        {
            int count = 0;
            foreach (var entity in entities)
            {
                Remove(entity);
                count++;
            }
            return count;
        }


    }
}
