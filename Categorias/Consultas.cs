using System;
using System.Linq;
using EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Categorias
{
    public class Consultas
    {
        private readonly AppDbContext _db;

        public Consultas()
        {
            _db = new AppDbContext();
        }

        public void TestandoFiltroConsultaGlobais()
        {
            //Configuração no AppDbContext
            //Trazer apenas os pedidos ATIVOS
            var pedidos = _db.Pedidos.ToList();

            foreach(var pedido in pedidos)
                Console.WriteLine(pedido.Solicitante);

            //ignorando filtro global
            var pedidosSemFiltro = _db.Pedidos.IgnoreQueryFilters().ToList();   

            foreach(var pedido in pedidosSemFiltro)
                Console.WriteLine(pedido.Solicitante); 
        }

        private void ConsultasEagerAndExplicityAndLazyLoading()
        {
            #region Eager - Carregamento Adiantado
            var resultadoEager = _db.Pedidos.Include(x => x.ItensPedido);
            #endregion

            #region Explicity - Carregamento explícito
            var resultadoExplicity = _db.Pedidos.ToList();
            //É necessário usar o .ToList() ou 
            //ativar o MultipleActiveResultsSets
            foreach(var pedido in resultadoExplicity)
            {
                if(pedido.Status == Enumerators.EStatus.Aberto)
                    _db.Entry(pedido).Collection(x => x.ItensPedido).Load();

                //OU

                _db.Entry(pedido)
                    .Collection(x => x.ItensPedido)
                    .Query() 
                    .Where(x => x.Valor > 500).ToList();
            }
            #endregion

            #region LazyLoading - Carregamento Lento Com Proxie
            
            //_db.ChangeTracker.LazyLoadingEnabled = false; //Desabilita o lazyloading para determinadas consultas 
            
            var resultadoLazyLoading = _db.Pedidos; 

            foreach(var pedido in resultadoLazyLoading)
            {
                Console.WriteLine($"{pedido.ItensPedido.Count()}");
            }
            #endregion 

            #region LazyLoading - Carregamento Lento Sem Proxie
            
            //Não é necessário o virtual e nem o UseLazyLoadingProxies no Contexto
            //É necessário algumas implementações na classe pai (Pedido)
            
            var resultadoLazyLoadingSemProxie = _db.Pedidos.ToList(); 

            foreach(var pedido in resultadoLazyLoadingSemProxie)
            {
                if(pedido.ItensPedido != null)
                    Console.WriteLine($"{pedido.ItensPedido.Count()}");
            }
            #endregion  
        }
    }
}