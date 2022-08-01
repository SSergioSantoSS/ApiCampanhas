using Microsoft.EntityFrameworkCore;
using ProjCampanhas.Domain.Entities;
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
    /// Classe de repositório para a entidade Campanha
    /// </summary>
    public class CampanhaRepository : BaseRepository<Campanha, Guid>, ICampanhaRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        //construtor para injeção de dependência
        public CampanhaRepository(SqlServerContext sqlServerContext) : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public Campanha GetByNome(string nome)
            => _sqlServerContext.Campanhas
                .AsNoTracking()
                .FirstOrDefault(c => c.Nome.Equals(nome));

        public Campanha GetByCodigo(string codigo)
            => _sqlServerContext.Campanhas
                .AsNoTracking()
                .FirstOrDefault(c => c.Codigo.Equals(codigo));

        public Campanha GetByTipoDeCampanha(Enum tipoDeCampanha)

            => _sqlServerContext.Campanhas
                .AsNoTracking()
                .FirstOrDefault(c => c.TipoDeCampanha.Equals(tipoDeCampanha));

    }

}
