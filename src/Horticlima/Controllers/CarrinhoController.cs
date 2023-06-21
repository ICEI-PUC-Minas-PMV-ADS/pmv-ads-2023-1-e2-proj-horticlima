using Horticlima.Models;
using Horticlima.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Horticlima.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly Carrinho _carrinho;
        private readonly ApplicationDbContext _context;

        public CarrinhoController(Carrinho carrinho, ApplicationDbContext context)
        {
            _carrinho = carrinho;
            _context = context;
        }

        public IActionResult Index(int user)
        {
            var itens = _carrinho.GetCarrinhoItems(user);
            _carrinho.CarrinhoItems = itens;

            var CarrinhoVw = new CarrinhoVw()
            {
                Carrinho = _carrinho,
                CarrinhoTotal = _carrinho.GetTotal(user)
            };
            return View(CarrinhoVw);
        }

        public IActionResult AdicionarItem(int? id, int user)
        {

            var carrinho = _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
            if (carrinho != null)
            {
                _carrinho.AdicionarItemNoCarrinho(carrinho, user);
            }
            return RedirectToAction("Index", "Carrinho", new { user = user });

        }

        public IActionResult RemoverItem(int id, int produto, int user)
        {
            var carrinho = _context.CarrinhoItens.Where(c => c.CarrinhoItemId == id && c.Produto.ProdutoId == produto).Include(c => c.Produto).FirstOrDefault();
            if (carrinho is not null)
            {
               _carrinho.RemoverItemNoCarrinho(carrinho);
            }
            return RedirectToAction("Index", "Carrinho", new { user = user });
        }
    }
}