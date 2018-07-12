using MicroOrm.Pocos.SqlGenerator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperTest.Models;
namespace DapperTest
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            Students = new StudentRepository(_connection, new SqlGenerator<Students>());
        }

        public IStudentRepository Students { get; private set; }

        public void Complete()
        {
             _connection.BeginTransaction().Commit();
        }

        public void Dispose()
        {
            _connection.BeginTransaction().Dispose();
        }

    }

    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        void Complete();

    }
}
