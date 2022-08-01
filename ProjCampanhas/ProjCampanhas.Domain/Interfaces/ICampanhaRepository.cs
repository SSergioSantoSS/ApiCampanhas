using ProjCampanhas.Domain.Core.Interfaces;
using ProjCampanhas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Domain.Interfaces
{
    /// <summary>
    /// Interface de repositório para a entidade Campanha
    /// </summary>
    public interface ICampanhaRepository : IRepository<Campanha, Guid>
    {
        Campanha GetByNome(string nome);
        Campanha GetByCodigo(string codigo);
        Campanha GetByTipoDeCampanha(Enum tipoDeCampanha);

    }
}
