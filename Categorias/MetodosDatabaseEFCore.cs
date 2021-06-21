using EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Categorias
{
    public class MetodosDatabaseEFCore
    {
        private readonly AppDbContext _db;

        public MetodosDatabaseEFCore()
        {
            _db = new AppDbContext();
        }

        public bool VerificaConexaoComOBanco() => _db.Database.CanConnect();

        public void MigrationEmTempoReal()
        {
            //Não é uma boa prática
            _db.Database.Migrate();
        }

        public void ComandosSqlComProtecaoSqlInjection()
        {
            var ataque = "teste ' or 1='";

            //errado
            _db.Database.ExecuteSqlRaw($"update pedidos set solicitante = 'ataque' where solicitante = '{ataque}'");

            //certo
            _db.Database.ExecuteSqlRaw("update pedidos set solicitante = 'ataque' where solicitante = {0}", ataque);
            _db.Database.ExecuteSqlInterpolated($"update pedidos set solicitante = 'ataque' where solicitante = {ataque}");
        }
    
        public void EnsureCreateAndDeleteDb()
        {
            _db.Database.EnsureDeleted(); //Apaga todo o banco de dados
            _db.Database.EnsureCreated(); //Cria todo o banco de dados sem migrations
        }
    }
}