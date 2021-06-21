using System;

namespace EFCore.Domain
{
    public class ItemPedido : EntityBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}