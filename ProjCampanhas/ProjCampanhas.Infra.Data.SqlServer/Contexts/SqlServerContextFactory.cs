using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Infra.Data.SqlServer.Contexts
{
    /// <summary>
    /// Classe para executar os comandos MIGRATIONS do EntityFramework
    /// </summary>
    public class SqlServerContextFactory : IDesignTimeDbContextFactory<SqlServerContext>
    {
        public SqlServerContext CreateDbContext(string[] args)
        {
            return null;//ToDo
        }
    }
}
