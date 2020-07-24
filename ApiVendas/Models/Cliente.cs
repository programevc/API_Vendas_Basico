using System;

namespace ApiVendas.Models
{
    public class Cliente : BaseModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DT_Nascimento { get; set; }
    }
}
