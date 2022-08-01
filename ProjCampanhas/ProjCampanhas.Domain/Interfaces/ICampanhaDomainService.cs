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
     /// Interface de serviço de domínio para Campanha
     /// </summary>
    public interface ICampanhaDomainService : IDomainService<Campanha, Guid>
    {
    }
}
