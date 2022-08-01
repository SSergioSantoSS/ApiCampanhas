using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Domain.Interfaces
{
    /// <summary>
    /// Interface para unidade de trabalho do repositório
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();


        #region Repositórios

        public ICampanhaRepository CampanhaRepository { get; }

        #endregion
    }
}
