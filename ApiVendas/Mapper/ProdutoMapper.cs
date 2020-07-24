using ApiVendas.Models;
using ApiVendas.Requests;
using ApiVendas.Responses;

namespace ApiVendas.Mapper
{
    public static class ProdutoMapper
    {
        public static Produto Mapper(ProdutoRequest ProdutoRequset)
        {
            return new Produto() { 
                Id = ProdutoRequset.Id,
                Descricao = ProdutoRequset.Descricao,
                Estoque = ProdutoRequset.Estoque,
                Valor = ProdutoRequset.Valor
            };
        }

        public static ProdutoResponse Mapper(Produto Produto)
        {
            return new ProdutoResponse();
            //return new ProdutoResponse()
            //{
            //    Id = Produto.Id.ToString(),
            //    Descricao = Produto.Descricao,
            //    //Estoque = Produto.Estoque.ToString(),
            //    Valor = Produto.Valor.ToString()
            //};
        }
    }
}
