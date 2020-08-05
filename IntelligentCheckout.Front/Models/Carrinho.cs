using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelligentCheckout.Front.Models
{
    public class Carrinho
    {
        public Guid IdSessao { get; set; }
        public List<ItemDeCompra> ItensDeCompra { get; set; }
        public int QuantidadeDeItens { get; set; }
        public decimal ValorTotalDoCarrinho { get; set; }

        public Carrinho()
        {
            ItensDeCompra = new List<ItemDeCompra>();
        }


        public void AdicionarItem(ItemDeCompra item)
        {
            if (!ItensDeCompra.Any(i => i.Produto.Id == item.Produto.Id))
            {
                ItensDeCompra.Add(item);
            }
            else
            {
                var itemExistente = ItensDeCompra.First(i => i.Produto.Id == item.Produto.Id);
                itemExistente.Quantidade = item.Quantidade;
            }
        }

    }
}
