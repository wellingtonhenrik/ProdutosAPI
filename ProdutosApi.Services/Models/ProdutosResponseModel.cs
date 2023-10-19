namespace ProdutosApi.Services.Models
{
    /// <summary>
    /// Modelo de dados para as respostar dos serviços POST, PUT e DELETE
    /// </summary>
    public class ProdutosResponseModel
    {
        public int? StatusCode { get; set; } 
        public string? Mensagem { get; set; }
        public ProdutosGetModel? Produto { get; set; } 
    }
}
