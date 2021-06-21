using System;
using System.Collections.Generic;
using EFCore.Data;
using EFCore.Categorias;
using EFCore.Domain;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Métodos comuns Database do EFCore
            var metodosDatabaseEFCore = new MetodosDatabaseEFCore();
            //metodosDatabaseEFCore.EnsureCreateAndDeleteDb();
            //metodosDatabaseEFCore.ComandosSqlComProtecaoSqlInjection();
            //metodosDatabaseEFCore.MigrationEmTempoReal();
            //metodosDatabaseEFCore.VerificaConexaoComOBanco();
            #endregion
            
            //PopulateDatabase();

            #region Consultas EFCore
            var consultas = new Consultas();    
            consultas.TestandoFiltroConsultaGlobais();
            #endregion
        }

        private static void PopulateDatabase()
        {
            var db = new AppDbContext();

            var pedido = new Pedido()
            {
                Solicitante = "Bruno",
                Data = DateTime.Now,
                Status = Enumerators.EStatus.Aberto,
                Ativo = true,
                ItensPedido = new List<ItemPedido>()
                {
                    new ItemPedido()
                    {
                        Nome = "Celular",
                        Valor = 600
                    },
                    new ItemPedido()
                    {
                        Nome = "TV",
                        Valor = 1600
                    }
                }
            };

            var pedido2 = new Pedido()
            {
                Solicitante = "João",
                Data = DateTime.Now,
                Status = Enumerators.EStatus.Aberto,
                Ativo = true,
                ItensPedido = new List<ItemPedido>()
                {
                    new ItemPedido()
                    {
                        Nome = "Sofá",
                        Valor = 1500
                    },
                    new ItemPedido()
                    {
                        Nome = "Mesa",
                        Valor = 2000
                    }
                }
            };

            var pedido3 = new Pedido()
            {
                Solicitante = "Maria",
                Data = DateTime.Now,
                Status = Enumerators.EStatus.Concluido,
                Ativo = false,
                ItensPedido = new List<ItemPedido>()
                {
                    new ItemPedido()
                    {
                        Nome = "Cama",
                        Valor = 1000
                    }
                }
            };

            db.AddRange(pedido, pedido2, pedido3);
            db.SaveChanges();
        }
    }
}
