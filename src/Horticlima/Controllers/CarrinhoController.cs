using Horticlima.Models;
using Horticlima.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Index()
        {
            var itens = _carrinho.GetCarrinhoItems();
            _carrinho.CarrinhoItems = itens;

            var CarrinhoVw = new CarrinhoVw()
            {
                Carrinho = _carrinho,
                CarrinhoTotal = _carrinho.GetTotal()
            };
            return View(CarrinhoVw);
        }

        public IActionResult AdicionarItem(int? id)
        {
            var carrinho = _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
            if (carrinho != null)
            {
                _carrinho.AdicionarItemNoCarrinho(carrinho);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoverItem(int? id)
        {
            var carrinho = _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
            if (carrinho != null)
            {
                _carrinho.RemoverItemNoCarrinho(carrinho);
            }
            return RedirectToAction("Index");
        }
    }
}
