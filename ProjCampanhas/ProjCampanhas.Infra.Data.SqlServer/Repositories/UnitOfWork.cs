using Microsoft.EntityFrameworkCore.Storage;
using ProjCampanhas.Domain.Interfaces;
using ProjCampanhas.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Infra.Data.SqlServer.Repositories
{
    /// <summary>
    /// Unidade de trabalho para acesso aos repositórios
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _sqlServerContext;

        public UnitOfWork(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        private IDbContextTransaction _dbContextTransaction;

        public void BeginTransaction()
        {
            _dbContextTransaction = _sqlServerContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContextTransaction.Commit();
        }

        public void RollbackTransaction()
        {
            _dbContextTransaction.Rollback();
        }

        public ICampanhaRepository CampanhaRepository => new CampanhaRepository(_sqlServerContext);

        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }
    }
}
