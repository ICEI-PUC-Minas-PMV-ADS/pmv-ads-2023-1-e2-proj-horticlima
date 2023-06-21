namespace Horticlima.Models
{
    public class CarrinhoItem
    {
        public int CarrinhoItemId { get; set; }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        public string CarrinhoId { get; set; }
        public Usuario Usuario { get; internal set; }
    }
}
