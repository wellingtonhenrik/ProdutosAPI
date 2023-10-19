using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Data.Entities
{
    /// <summary>
    /// MOdelo da entidade Produto do banco de dados
    /// </summary>
    public class Produto
    {
        public Guid? ProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public DateTime? DataHoraUltimaAlteracao { get; set; }
    }
}
