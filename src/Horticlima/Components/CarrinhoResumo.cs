using Horticlima.Models;
using Horticlima.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horticlima.Components
{
    public class CarrinhoResumo : ViewComponent
    {
        private readonly Carrinho _carrinho;

        public CarrinhoResumo(Carrinho carrinho)
        {
            _carrinho = carrinho;
        }

        public IViewComponentResult Invoke()
        {
            var itens = _carrinho.GetCarrinhoItems();
            _carrinho.CarrinhoItems = itens;

            var carrinhoVw = new CarrinhoVw()
            {
                Carrinho = _carrinho,
                CarrinhoTotal = _carrinho.GetTotal()
            };
            return View(carrinhoVw);
        }

    }
}
