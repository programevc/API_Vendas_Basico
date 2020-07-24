namespace ApiVendas.Models
{
    public class PedidoItem : BaseModel
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor_Unitario { get; set; }
        public Produto Produto { get; set; }
    }
}
