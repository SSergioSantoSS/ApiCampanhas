using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjLg.Api.Tests.Helpers
{
    public class TestsHelper
    {
        /// <summary>
        /// Executando a API e criando um objeto Client HTTP
        /// </summary>
        public static HttpClient CreateClient()
        {
            var application = new WebApplicationFactory<Program>();
            return application.CreateClient();
        }

        /// <summary>
        /// Método para serializar objetos C# em JSON para envio de serviços de API
        /// </summary>
        public static StringContent CreateContent<TRequest>(TRequest request)
        {
            return new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Método para deserializar o retorno de uma API (JSON) para objeto C#
        /// </summary>
        public static TResponse CreateResponse<TResponse>(HttpResponseMessage message)
        {
            return JsonConvert.DeserializeObject<TResponse>
                (message.Content.ReadAsStringAsync().Result);

        }
    }
}