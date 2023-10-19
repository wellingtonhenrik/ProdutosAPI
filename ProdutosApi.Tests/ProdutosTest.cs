using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using ProdutosApi.Services.Controllers;
using ProdutosApi.Services.Models;
using ProdutosApi.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProdutosApi.Tests
{
    public class ProdutosTest
    {
        private static string Endpoint => "api/produtos";
        [Fact()]
        public async Task<ProdutosGetModel> Produtos_Post_Returns_Created()
        {
            //criando os dados para cadastro do produto
            var faker = new Faker("pt_BR");
            var request = new ProdutosPostRequestModel
            {
                Descricao = faker.Commerce.ProductDescription(),
                Nome = faker.Commerce.ProductName(),
                Preco = decimal.Parse(faker.Commerce.Price()),
                Quantidade = faker.Random.Int(1, 100),
            };

            //executando o serviço de cadastro de produtos POST /api/produtos
            var result = await TestHelper.CreateClient().PostAsync(Endpoint, TestHelper.CreateContent(request));

            //verificando se o resultado passou no teste
            result.StatusCode
                .Should() // o status code obtido deverá ser igual a 201
                .Be(HttpStatusCode.Created);

            //deserializando o retorno obtido na API
            var response = TestHelper.ReadContent<ProdutosResponseModel>(result);

            //verificações
            response.StatusCode.Should().Be(201);
            response.Mensagem.Should().Be(ProdutosController.CreateMessage);
            response.Produto.Should().NotBeNull();

            return response.Produto;

        }
        [Fact()]
        public async Task Produtos_Put_Returns_OK()
        {
            //cadastrar um produto
            var produto = await Produtos_Post_Returns_Created();

            //modificando dados do produto
            var faker = new Faker("pt_BR");
            var request = new ProdutosPutResquestModel
            {
                ProdutoId = produto.ProdutoId,
                Descricao = faker.Commerce.ProductDescription(),
                Nome = faker.Commerce.ProductName(),
                Preco = decimal.Parse(faker.Commerce.Price()),
                Quantidade = faker.Random.Int(1, 100),
            };

            //executando o serviço de cadastro de produtos PUT /api/produtos
            var result = await TestHelper.CreateClient().PutAsync(Endpoint, TestHelper.CreateContent(request));

            //verificando se o resultado passou no teste
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            //deserializando o retorno obtido na API
            var response = TestHelper.ReadContent<ProdutosResponseModel>(result);

            //verificações
            response.StatusCode.Should().Be(200);
            response.Mensagem.Should().Be(ProdutosController.UpdateMessage);
            response.Produto.Should().NotBeNull();


        }
        [Fact()]
        public async Task Produtos_Delete_Returns_Ok()
        {
            //cadastrar um produto
            var produto = await Produtos_Post_Returns_Created();

            var result = await TestHelper.CreateClient().DeleteAsync(Endpoint + "/" + produto.ProdutoId);

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var response = TestHelper.ReadContent<ProdutosResponseModel>(result);

            response.StatusCode.Should().Be(200);
            response.Mensagem.Should().Be(ProdutosController.DeleteMessage);
            response.Produto.Should().NotBeNull();

        }
        [Fact()]
        public async Task Produtos_GetAll_Returns_Ok()
        {
            var produto = new ProdutosGetModel();
            for (int i = 0; i <= 3; i++)
            {
                produto = await Produtos_Post_Returns_Created();
            }

            var result = await TestHelper.CreateClient().GetAsync(Endpoint);

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var response = TestHelper.ReadContent<List<ProdutosGetModel>>(result);

            response.Should().NotBeEmpty();

            response.FirstOrDefault(a => a.ProdutoId == produto.ProdutoId).Should().NotBeNull();
        }
        [Fact()]
        public async Task Produtos_GetById_Returns_Ok()
        {
            var produto = await Produtos_Post_Returns_Created();

            var result = await TestHelper.CreateClient().GetAsync(Endpoint + "/" + produto.ProdutoId);

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var response = TestHelper.ReadContent<ProdutosGetModel>(result);

            response.Should().NotBeNull();

            response.ProdutoId.Should().Be(produto.ProdutoId);
            response.Nome.Should().Be(produto.Nome);
            response.Preco.Should().Be(produto.Preco);
            response.Quantidade.Should().Be(produto.Quantidade);
        }
    }
}
