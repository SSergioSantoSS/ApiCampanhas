using ProjCampanhas.Application.Commands;
using ProjCampanhas.Application.Models;
using ProjCampanhas.Infra.Cache.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Application.Interfaces
{
    public interface ICampanhaAppService : IDisposable
    {
        #region Commands
        Task<CampanhaDto> Create(CampanhaCreateCommand command);
        Task<CampanhaDto> Update(CampanhaUpdateCommand command);
        Task<CampanhaDto> Delete(CampanhaDeleteCommand command);

        #endregion

        #region Queries

        List<CampanhasModel> GetAll(int page, int limit);
        CampanhasModel GetById(Guid id);

        #endregion
    }
}
