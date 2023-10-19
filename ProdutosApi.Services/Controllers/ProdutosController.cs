using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApi.Data.Entities;
using ProdutosApi.Data.Repositories;
using ProdutosApi.Services.Models;

namespace ProdutosApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        #region Menssagens

        public static string CreateMessage => "Produto cadastrado com sucesso";
        public static string UpdateMessage => "Produto atualizado com sucesso";
        public static string DeleteMessage => "Produto excluído com sucesso";
        public static string NotFoundMessage => "Produto não encontrado, verifique o ID informado";

        #endregion
        private readonly ProdutoRepository _produtoRepository;
        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        /// <summary>
        /// Serviço para cadastro do produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProdutosResponseModel), 201)]

        public IActionResult Post(ProdutosPostRequestModel model, [FromServices] IMapper mapper)
        {
            try
            {
                var produto = mapper.Map<Produto>(model);

                _produtoRepository.Add(produto);
                var response = new ProdutosResponseModel
                {
                    Mensagem = CreateMessage,
                    StatusCode = 201, //CREATED
                    Produto = mapper.Map<ProdutosGetModel>(produto),
                };

                return StatusCode(201, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensgem = $"Falha ao cadastrar produto: {ex.Message}" });

            }
        }

        /// <summary>
        /// Serviço para alteração do produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ProdutosResponseModel), 200)]
        public IActionResult Put(ProdutosPutResquestModel model, [FromServices] IMapper mapper)
        {
            try
            {
                {
                    var produtoBase = _produtoRepository.Get(model.ProdutoId.Value);

                    if (produtoBase == null) return StatusCode(401, NotFoundMessage);

                    produtoBase.Nome = model.Nome;
                    produtoBase.Descricao = model.Descricao;
                    produtoBase.Quantidade = model.Quantidade;
                    produtoBase.Preco = model.Preco;
                    produtoBase.DataHoraUltimaAlteracao = DateTime.Now;

                    _produtoRepository.Update(produtoBase);

                    var response = new ProdutosResponseModel
                    {
                        StatusCode = 200,
                        Mensagem = UpdateMessage,
                        Produto = mapper.Map<ProdutosGetModel>(produtoBase),
                    };

                    return Ok(response);


                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Falha ao atualizar produto: {ex.Message}" });
            }

        }

        /// <summary>
        /// Serviço para exclusão do produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutosResponseModel), 200)]
        public IActionResult Delete(Guid id, [FromServices] IMapper mapper)
        {
            try
            {
                var produto = _produtoRepository.Get(id);

                if (produto is null) return NoContent();

                _produtoRepository.Delete(produto);

                var response = new ProdutosResponseModel
                {
                    StatusCode = 200,
                    Mensagem = DeleteMessage,
                    Produto = mapper.Map<ProdutosGetModel>(produto),
                };

                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Falha ao deletar produto: {ex.Message}" });
            }
        }

        /// <summary>
        /// Serviço para retornar todos os produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosResponseModel>), 200)]
        public IActionResult GetAll([FromServices] IMapper mapper)
        {
            try
            {
                var produtosBase = _produtoRepository.GetAll();

                if (produtosBase.Count == 0) return NoContent();// HTTP 204(vazio)

                return StatusCode(200, mapper.Map<List<ProdutosGetModel>>(produtosBase));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { messagem = $"Falha ao consultar todos os produto: {ex.Message}" });
            }
        }

        /// <summary>
        /// Serviço para retornar um unico produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosResponseModel), 200)]
        public IActionResult GetById(Guid id, [FromServices] IMapper mapper)
        {
            try
            {
                var produtobase = _produtoRepository.Get(id);

                if (produtobase is null) return NoContent(); // HTTP 204 (vazio);

                return StatusCode(200, mapper.Map<ProdutosGetModel>(produtobase));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"Falha ao consultar produto: {ex.Message}" });
            }
        }
    }
}
