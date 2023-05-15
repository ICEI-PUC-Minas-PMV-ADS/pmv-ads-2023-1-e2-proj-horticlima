using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void AdicionarItemNoCarrinho(Produto produto)
        {
            var itens = _appDbContext.CarrinhoItens
                .FirstOrDefault(x => x.Produto.ProdutoId == produto.ProdutoId && x.CarrinhoId == CarrinhoId);
            if (itens == null)
            {
                itens = new CarrinhoItem()
                {
                    Produto = produto,
                    Quantidade = 1,
                    CarrinhoId = CarrinhoId
                };
                _appDbContext.CarrinhoItens.Add(itens);
            }
            else
            {
                itens.Quantidade++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoverItemNoCarrinho(Produto produto)
        {
            var itens = _appDbContext.CarrinhoItens
                .FirstOrDefault(x => x.Produto.ProdutoId == produto.ProdutoId && x.CarrinhoId == CarrinhoId);
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

        public IList<CarrinhoItem> GetCarrinhoItems()
        {
            return CarrinhoItems ?? (CarrinhoItems = _appDbContext.CarrinhoItens
                .Where(x => x.CarrinhoId == CarrinhoId).
                Include(x => x.Produto).
                ToList());
        }

        public void LimparCarrinho()
        {
            var clear = _appDbContext.CarrinhoItens
                .Where(x => x.CarrinhoId == CarrinhoId);
            _appDbContext.CarrinhoItens.RemoveRange(clear);
            _appDbContext.SaveChanges();
        }

        public decimal GetTotal()
        {
            var total = _appDbContext.CarrinhoItens
                .Where(x => x.CarrinhoId == CarrinhoId)
                .Select(x => x.Quantidade * x.Produto.Preco)
                .Sum();

            return total;
        }
    }
}
