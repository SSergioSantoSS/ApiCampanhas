using Bogus;
using FluentAssertions;
using ProjLg.Api.Tests.Helpers;
using ProjLg.Services.Api.Entities;
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
    public class RegisterTests
    {
        private readonly string _endpoint;

        public RegisterTests()
        {
            _endpoint = "/api/register";
        }

        [Fact]
        public async Task<Usuario> Register_Post_Returns_Ok()
        {
            var faker = new Faker("pt_BR");

            var model = new RegisterViewModel
            {
                Nome = faker.Person.FullName,
                Email = faker.Person.Email.ToLower(),
                Senha = faker.Internet.Password(8)
            };

            var client = TestsHelper.CreateClient();
            var result = await client.PostAsync(_endpoint, TestsHelper.CreateContent(model));

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var usuario = TestsHelper.CreateResponse<Usuario>(result);

            usuario.Should().NotBeNull();

            usuario.Id.Should().NotBeEmpty();
            usuario.Nome.Should().Be(model.Nome);
            usuario.Email.Should().Be(model.Email);
            usuario.DataCriacao.Should().NotBeNull();

            usuario.Senha = model.Senha;
            return usuario;
        }



        [Fact]
        public async Task Register_Post_Returns_BadRequest()
        {
            //gravando um usuário na API
            var usuario = await Register_Post_Returns_Ok();

            var model = new RegisterViewModel
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            };

            var client = TestsHelper.CreateClient();
            var result = await client.PostAsync(_endpoint, TestsHelper.CreateContent(model));

            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}




            
