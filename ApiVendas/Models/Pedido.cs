using System;
using System.Collections.Generic;

namespace ApiVendas.Models
{
    public class Pedido: BaseModel
    {
        public Pedido()
        {
            Itens = new List<PedidoItem>();

        }
        public int Nr_Pedido { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public Cliente Cliente { get; set; }
        public List<PedidoItem> Itens { get; set; }
    }
}
