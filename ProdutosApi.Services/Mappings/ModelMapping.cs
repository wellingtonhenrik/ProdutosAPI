using AutoMapper;
using ProdutosApi.Data.Entities;
using ProdutosApi.Services.Models;

namespace ProdutosApi.Services.Mappings
{

    /// <summary>
    /// Classe para configurar os mapeamentos
    /// que serão realizados pelo AutoMapper
    /// </summary>
    public class ModelMapping : Profile
    {
        public ModelMapping()
        {
            //Mapear a cópia dos dados da classe [ProdutosPostRequest]
            //para a classe de entidade [Produto]
            CreateMap<ProdutosPostRequestModel, Produto>()
                .AfterMap((model, entity) =>
                {
                    entity.ProdutoId = Guid.NewGuid();
                    entity.DataHoraCadastro = DateTime.Now;
                    entity.DataHoraUltimaAlteracao = DateTime.Now;
                });

            //Mapear a cópia dos dadsos da classe [Produto]
            //para a classe [ProdutosGetModel]
            CreateMap<Produto, ProdutosGetModel>()
                .AfterMap((model, entity) =>
                {
                    entity.Total = entity.Preco * entity.Quantidade;
                });
        }
    }
}
