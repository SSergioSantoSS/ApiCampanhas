using Bogus;
using FluentAssertions;
using ProjCampanhas.Application.Commands;
using ProjCampanhas.Services.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjCampanhas.Services.Tests
{
    public class CampanhasTests
    {
        private readonly string _endpoint;

        public CampanhasTests()
        {
            _endpoint = "/api/campanhas";
        }

        [Fact]
        public async Task Campanha_Post_Returns_Ok()
        {
            var faker = new Faker("pt_BR");

            var command = new CampanhaCreateCommand
            {
                Nome = faker.Person.FullName,
                Codigo = faker.Address.County()              
               

            };

            var client = TestsHelper.CreateClient();
            var result = await client.PostAsync(_endpoint, TestsHelper.CreateContent(command));

            result.StatusCode.Should().Be(HttpStatusCode.Created);
        }

    }
}
