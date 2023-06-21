using Horticlima.Models;
using Microsoft.AspNetCore.Mvc;

namespace Horticlima.Controllers
{
    public class PedidoController : Controller
    {
        private readonly Carrinho _carrinho;
        private readonly ApplicationDbContext _context;

        public PedidoController(Carrinho carrinho, ApplicationDbContext context)
        {
            _carrinho = carrinho;
            _context = context;
        }

   

        public IActionResult Index(int pedido,int user)
        {
            var itens = _carrinho.GetCarrinhoItemsCheckout(pedido);
            _carrinho.CarrinhoItems = itens;

            var CarrinhoVw = new Horticlima.ViewModels.CarrinhoVw()
            {
                Carrinho = _carrinho,
                CarrinhoTotal = _carrinho.GetTotal(user)
            };
            return View(CarrinhoVw);
        }

        public IActionResult Checkou()
        {
            return View();
        }
        
    }
}
