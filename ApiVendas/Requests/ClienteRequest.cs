using System;

namespace ApiVendas.Requests
{
    public class ClienteRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DT_Nascimento { get; set; }
    }
}
