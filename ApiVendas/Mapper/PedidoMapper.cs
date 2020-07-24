using ApiVendas.Models;
using ApiVendas.Requests;
using ApiVendas.Responses;
using System.Linq;

namespace ApiVendas.Mapper
{
    public static class PedidoMapper
    {
        public static Pedido Mapper(PedidoRequest PedidoRequest)
        {
            return new Pedido()
            {
                Nr_Pedido = PedidoRequest.Nr_Pedido,
                Tipo = PedidoRequest.Tipo,
                Data = PedidoRequest.DT_Pedido,
                Cliente = ClienteMapper.Mapper(PedidoRequest.Cliente),
                Itens = PedidoRequest.Itens.Select(p => PedidoItemMapper.Mapper(p)).ToList()
            };
        }
        public static PedidoResponse Mapper(Pedido Pedido)
        {
            return new PedidoResponse()
            {
                Nr_Pedido = Pedido.Nr_Pedido.ToString(),
                Tipo = Pedido.Tipo.ToString(),
                DT_Pedido = Pedido.Data.ToString(),
                Cliente = ClienteMapper.Mapper(Pedido.Cliente),
                Itens = Pedido.Itens.Select(p => PedidoItemMapper.Mapper(p)).ToList()
            };
        }
    }
}
