using System;
using System.Collections.Generic;
using EFCore.Enumerators;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore.Domain
{
    public class Pedido : EntityBase
    {
        public string Solicitante { get; set; }
        public DateTime Data { get; set; }
        public EStatus Status { get; set; }
        public bool Ativo { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
        
        #region  Lazy Loading Forma 1
        /*
        public Pedido()
        {
        }

        private Action<object,string> _lazyLoader { get; set; }
        private Pedido(Action<object,string> lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        private List<ItemPedido> _ItensPedido;
        public List<ItemPedido> ItensPedido
        {
            get 
            {
                _lazyLoader?.Invoke(this, nameof(ItensPedido));
                return _ItensPedido;
            }
            set => _ItensPedido = value;
        }
        */
        #endregion

        #region  Lazy Loading Forma 2
        /*
        public Pedido()
        {
        }

        private ILazyLoader _lazyLoader { get; set; }
        private Pedido(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        private List<ItemPedido> _ItensPedido;
        public List<ItemPedido> ItensPedido
        {
            get => _lazyLoader.Load(this, ref _ItensPedido);
            set => _ItensPedido = value;
        }
        */
        #endregion
    }   
}