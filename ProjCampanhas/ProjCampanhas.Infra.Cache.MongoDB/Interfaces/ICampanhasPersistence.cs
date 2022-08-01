using ProjCampanhas.Infra.Cache.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Infra.Cache.MongoDB.Interfaces
{
    /// <summary>
    /// Interfaces para definir as operações da Collection Campanhas no MongoDB
    /// </summary>
    public interface ICampanhasPersistence
    {
        void Create(CampanhasModel model);
        void Update(CampanhasModel model);
        void Delete(CampanhasModel model);

        List<CampanhasModel> GetAll(int page, int limit);
        CampanhasModel GetById(Guid id);
    }
}
