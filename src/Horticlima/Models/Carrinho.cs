using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Horticlima.Models
{
    [Table("Carrinho")]
    public class Carrinho
    {
        public int CarrinhoId { get; set; }
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsarioId")]
        public Usuario Usuario { get; set; }
    }
}
