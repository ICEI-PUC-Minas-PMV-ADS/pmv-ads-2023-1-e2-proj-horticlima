using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Horticlima.Models
{
    public class Carrinho
    {
        private readonly ApplicationDbContext _appDbContext;

        public Carrinho(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IList<CarrinhoItem> CarrinhoItems { get; set; }

        public string CarrinhoId { get; set; }

        public static Carrinho GetCarrinho(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            var context = service.GetService<ApplicationDbContext>();
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();
            session.SetString("CarrinhoId", carrinhoId);

            return new Carrinho(context)
            {
                CarrinhoId = carrinhoId
            };
        }

        public void AdicionarItemNoCarrinho(Produto produto, int Usuario)
        {
            var itens = _appDbContext.CarrinhoItens
                .FirstOrDefault(x => x.Produto.ProdutoId == produto.ProdutoId && x.CarrinhoId == CarrinhoId && x.Usuario.UsuarioId == Usuario);

            var usuario = _appDbContext.Usuarios
           .FirstOrDefault(x => x.UsuarioId == Usuario);



            if (itens == null)
            {
                itens = new CarrinhoItem()
                {
                    Produto = produto,
                    Quantidade = 1,
                    CarrinhoId = CarrinhoId,
                    Usuario = usuario
                };
                _appDbContext.CarrinhoItens.Add(itens);
            }
            else
            {
                itens.Quantidade++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoverItemNoCarrinho(CarrinhoItem carrinhoItem)
        {
            var itens = _appDbContext.CarrinhoItens
                .FirstOrDefault(x => x.Produto.ProdutoId == carrinhoItem.Produto.ProdutoId && x.CarrinhoItemId == carrinhoItem.CarrinhoItemId);
            var quantity = 0;
            if (itens != null)
            {
                if (itens.Quantidade > 1)
                {
                    itens.Quantidade--;
                    quantity = itens.Quantidade;
                }
                else
                {
                    _appDbContext.CarrinhoItens.Remove(itens);
                }
            }
            _appDbContext.SaveChanges();
            return quantity;
        }

        public IList<CarrinhoItem> GetCarrinhoItemsCheckout(int carrinho)
        {
            return CarrinhoItems ?? (CarrinhoItems = _appDbContext.CarrinhoItens
                .Where(x => x.CarrinhoItemId == carrinho).
                Include(x => x.Produto).
                Include(x => x.Usuario).
                ToList());
        }


        public IList<CarrinhoItem> GetCarrinhoItems(int User)
        {
            return CarrinhoItems ?? (CarrinhoItems = _appDbContext.CarrinhoItens
                .Where(x => x.CarrinhoId == CarrinhoId && x.Usuario.UsuarioId == User).
                Include(x => x.Produto).
                Include(x => x.Usuario).
                ToList());
        }

        public void LimparCarrinho()
        {
            var clear = _appDbContext.CarrinhoItens
                .Where(x => x.CarrinhoId == CarrinhoId);
            _appDbContext.CarrinhoItens.RemoveRange(clear);
            _appDbContext.SaveChanges();
        }

        public decimal GetTotal(int User)
        {
            var total = _appDbContext.CarrinhoItens
                .Where(x => x.CarrinhoId == CarrinhoId && x.Usuario.UsuarioId == User)
                .Select(x => x.Quantidade * x.Produto.Preco)
                .Sum();

            return total;
        }
    }
}