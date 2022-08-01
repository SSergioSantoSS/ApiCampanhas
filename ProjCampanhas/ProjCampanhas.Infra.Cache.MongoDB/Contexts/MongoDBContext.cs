using MongoDB.Driver;
using ProjCampanhas.Infra.Cache.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Infra.Cache.MongoDB.Contexts
{
    /// <summary>
    /// Classe para conexão com o banco de dados MongoDB
    /// </summary>
    public class MongoDBContext
    {
        private readonly MongoDBSettings _mongoDBSettings;
        private IMongoDatabase _mongoDatabase;

        public MongoDBContext(MongoDBSettings mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings;

            #region Conectando no Banco de dados

            var cliente = MongoClientSettings.FromUrl(new MongoUrl(_mongoDBSettings.Host));

            if (_mongoDBSettings.IsSSl)
            {
                cliente.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };

            }
            _mongoDatabase = new MongoClient(cliente).GetDatabase(_mongoDBSettings.Name);

            #endregion
        }

        /// <summary>
        /// Mapeando um documento / Collection para a gravação no MongoDB
        /// </summary>
        public IMongoCollection<CampanhasModel> Campanhas
            => _mongoDatabase.GetCollection<CampanhasModel>("Campanhas");

    }
}
