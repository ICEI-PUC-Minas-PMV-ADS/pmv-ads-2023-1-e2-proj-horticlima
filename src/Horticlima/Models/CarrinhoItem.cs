using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Horticlima.Models
{
    public class CarrinhoItem
    {
        public int CarrinhoItemId { get; set; }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        public string CarrinhoId { get; set; }

    }
}
