using Dapper.Contrib.Extensions;

namespace ApiVendas.Models
{
    [Table("produto")]
    public class Produto : BaseModel
    {
        [ExplicitKey]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public decimal Valor { get; set; }
    }
}
