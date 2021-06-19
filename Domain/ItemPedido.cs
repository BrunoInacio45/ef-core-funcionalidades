namespace EFCore.Domain
{
    public class ItemPedido : EntityBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}