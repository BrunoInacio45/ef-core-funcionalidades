using System;
using System.Diagnostics;
using System.Linq;
using EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new AppDbContext();

            #region Cria todo o banco de dados sem a necessidade de migrations
            //EnsureCreateAndDeleteDb(dbContext);
            #endregion

            #region Forma de como verificar se a aplicação pode se conectar com o db
            //VerificaConexaoComOBanco(dbContext);
            #endregion

            #region Estratégia de melhor desempenho (Consulta dentro de um for)
            //Levou 00:00:04.1575649 tempo
            MelhorandoDesempenhoDeConsultasDentroDeUmFor(dbContext, false);
            //Levou 00:00:00.1091444 tempo
            MelhorandoDesempenhoDeConsultasDentroDeUmFor(dbContext, true);
            #endregion

        }

        private static void MelhorandoDesempenhoDeConsultasDentroDeUmFor(AppDbContext db, bool abreConexaoPrematura)
        {
            var conexao = db.Database.GetDbConnection(); //Pega a instancia do objeto de conexão

            var sw = new Stopwatch();

            if(abreConexaoPrematura) conexao.Open(); //Abre uma conexão

            sw.Start();
            for(var i = 0; i < 500; i++)
            {
                //Sem abrir uma conexão antes,
                //o ef abre e fecha a conexão 500 vezes
                //com o conexao.Open(), apenas uma conexão é aberta
                db.Pedidos.AsNoTracking().Any(); 
            }
            sw.Stop();

            Console.WriteLine($"Levou {sw.Elapsed} tempo");
        }

        private static bool VerificaConexaoComOBanco(AppDbContext db) => db.Database.CanConnect();
        
        private static void EnsureCreateAndDeleteDb(AppDbContext db)
        {
            //db.Database.EnsureCreated(); //Cria todo o banco de dados 
            //db.Database.EnsureDeleted(); //Apaga todo o banco de dados
        }
    }
}
