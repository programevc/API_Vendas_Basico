using System;
using System.Collections.Generic;

namespace ApiVendas.Requests
{
    public class PedidoRequest
    {
        public int Nr_Pedido { get; set; }
        public DateTime DT_Pedido { get; set; }
        public string Tipo { get; set; }
        public ClienteRequest Cliente { get; set; }
        public List<PedidoItemRequest> Itens { get; set; }
    }
}
