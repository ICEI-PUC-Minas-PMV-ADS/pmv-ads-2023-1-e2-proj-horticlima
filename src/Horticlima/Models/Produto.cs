using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Horticlima.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto")]
        public string ProdutoNome { get; set; }

        [Required(ErrorMessage = "Informe a descrição do produto")]
        public string ProdutoDescricao { get; set; }

        public string ProdutoImagemURL { get; set; }

        [NotMapped]
        [Display(Name = "Escolha o arquivo de imagem do produto")]
        [Required]
        public IFormFile ProdutoImagemArquivo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o preço o produto!")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a categoria do produto!")]
        public Categoria Categoria { get; set; }
    }

    public enum Categoria
    {
        Frutas,
        Verduras,
        Legumes
    }
}
