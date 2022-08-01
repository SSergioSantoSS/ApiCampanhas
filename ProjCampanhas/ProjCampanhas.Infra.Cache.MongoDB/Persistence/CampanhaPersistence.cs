using MongoDB.Driver;
using ProjCampanhas.Infra.Cache.MongoDB.Contexts;
using ProjCampanhas.Infra.Cache.MongoDB.Interfaces;
using ProjCampanhas.Infra.Cache.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Infra.Cache.MongoDB.Persistence
{
    public class CampanhasPersistence : ICampanhasPersistence
    {
        //atributo
        private readonly MongoDBContext _mongoDBContext;

        //injeção de dependência
        public CampanhasPersistence(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public void Create(CampanhasModel model)
        {
            _mongoDBContext.Campanhas.InsertOne(model);
        }

        public void Update(CampanhasModel model)
        {
            var filter = Builders<CampanhasModel>.Filter.Eq(c => c.Id, model.Id);
            _mongoDBContext.Campanhas.ReplaceOne(filter, model);
        }

        public void Delete(CampanhasModel model)
        {
            var filter = Builders<CampanhasModel>.Filter.Eq(c => c.Id, model.Id);
            _mongoDBContext.Campanhas.DeleteOne(filter);
        }

        public List<CampanhasModel> GetAll(int page, int limit)
        {
            var filter = Builders<CampanhasModel>.Filter.Where(c => true);
            return _mongoDBContext.Campanhas
                .Find(filter)
                .Skip(page)
                .Limit(limit)
                .ToList();
        }

        public CampanhasModel GetById(Guid id)
        {
            var filter = Builders<CampanhasModel>.Filter.Eq(c => c.Id, id);
            return _mongoDBContext.Campanhas
                .Find(filter)
                .FirstOrDefault();
        }
    }
}
