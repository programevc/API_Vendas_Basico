using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVendas.Responses
{
    public class PedidoItemResponse
    {
        public string Id { get; set; }
        public string Quantidade { get; set; }
        public string Valor_Unitario { get; set; }
        public ProdutoResponse Produto { get; set; }
    }
}
