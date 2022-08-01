using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Infra.Cache.MongoDB.Contexts
{
    /// <summary>
    /// Classe para capturar os parametros de config. para acesso ao MONGODB
    /// </summary>
    public class MongoDBSettings
    {
        public string? Host { get; set; }
        public string? Name { get; set; }
        public bool IsSSl { get; set; }

    }
}
