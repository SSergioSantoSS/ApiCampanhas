using Bogus;
using FluentAssertions;
using ProjLg.Api.Tests.Helpers;
using ProjLg.Services.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjLg.Api.Tests
{
    public class LoginTests
    {
        private readonly string _endpoint;

        public LoginTests()
        {
            _endpoint = "/api/login";
        }

        [Fact]
        public async Task Login_Post_Returns_Ok()
        {
            var usuario = await new RegisterTests().Register_Post_Returns_Ok();

            var model = new LoginViewModel
            {
                Email = usuario.Email,
                Senha = usuario.Senha
            };

            var client = TestsHelper.CreateClient();
            var result = await client.PostAsync(_endpoint, TestsHelper.CreateContent(model));

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Login_Post_Returns_BadRequest()
        {
            var faker = new Faker("pt_BR");

            var model = new LoginViewModel
            {
                Email = faker.Person.Email,
                Senha = faker.Internet.Password(8)
            };

            var client = TestsHelper.CreateClient();
            var result = await client.PostAsync(_endpoint, TestsHelper.CreateContent(model));

            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}


        
