using System.ComponentModel.DataAnnotations;

namespace ProdutosApi.Services.Models
{

    /// <summary>
    /// Modelo de dados para arequisição do seerviço POst /api/Produtos
    /// </summary>
    public class ProdutosPostRequestModel
    {
        [MinLength(2, ErrorMessage = "Informe no minimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres")]
        [Required(ErrorMessage = "Informe campo {0}")]
        public string? Nome { get; set; }

        [MinLength(2, ErrorMessage = "Informe no minimo {1} caracteres")]
        [MaxLength(250, ErrorMessage = "Informe no máximo {1} caracteres")]

        [Required(ErrorMessage = "Informe campo {0}")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Informe campo {0}")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Informe campo {0}")]
        public int? Quantidade { get; set; }
    }
}
