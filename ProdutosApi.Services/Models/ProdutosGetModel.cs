namespace ProdutosApi.Services.Models
{/// <summary>
/// Modelo de dados para consulta de proutos
/// </summary>
    public class ProdutosGetModel
    {
        public Guid? ProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Total { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }
    }
}
