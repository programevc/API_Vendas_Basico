using ApiVendas.Models;
using ApiVendas.Requests;
using ApiVendas.Responses;

namespace ApiVendas.Mapper
{
    public static class PedidoItemMapper
    {
        public static PedidoItem Mapper(PedidoItemRequest PedidoItem)
        {
            return new PedidoItem()
            {
                Id = PedidoItem.Id,
                Produto = ProdutoMapper.Mapper(PedidoItem.Produto),
                Quantidade = PedidoItem.Quantidade,
                Valor_Unitario = PedidoItem.Valor_Unitario
            };
        }

        public static PedidoItemResponse Mapper(PedidoItem PedidoItem)
        {
            return new PedidoItemResponse()
            {
                Id = PedidoItem.Id.ToString(),
                Produto = ProdutoMapper.Mapper(PedidoItem.Produto),
                Quantidade = PedidoItem.Quantidade.ToString(),
                Valor_Unitario = PedidoItem.Valor_Unitario.ToString()
            };
        }
    }
}
