using System;
using System.Collections.Generic;
using EFCore.Enumerators;

namespace EFCore.Domain
{
    public class Pedido : EntityBase
    {
        public string Solicitante { get; set; }
        public DateTime Data { get; set; }
        public EStatus Status { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }
    }
}