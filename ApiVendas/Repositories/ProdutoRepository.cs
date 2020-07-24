using ApiVendas.Models;
using ApiVendas.Responses;
using System.Collections.Generic;

namespace ApiVendas.Repositories
{
    public static class ProdutoRepository
    {
        public static ReturnResponse Gravar(Produto produto)
        {
            try
            {
                BaseRepository.Command(produto);
                return new ReturnResponse(200, "Produto Cadastrado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao cadastrar erro:", ex.Message));
            }
        }
        public static ReturnResponse Atualizar(Produto produto)
        {
            try
            {
                BaseRepository.Command(produto, true);
                return new ReturnResponse(200, "Produto atualizado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao atualizar erro:", ex.Message));
            }
        }
        public static ReturnResponse Delete(int id)
        {
            try
            {
                BaseRepository.Delete<Produto>(id);
                return new ReturnResponse(200, "Produto deletado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao deletar erro:", ex.Message));
            }
        }
        public static List<Produto> Buscar(int id = 0, string desricao = "")
        {
            string sql = "select * from produto";

            if (id > 0)
            {
                sql += " where id = @idProduto";
            }

            if (!string.IsNullOrEmpty(desricao))
            {
                if (sql.Contains("where"))
                    sql += " and descricao like @descricaoProduto";
                else
                    sql += " where descricao like @descricaoProduto";
            }

            var retorno = BaseRepository.QuerySql<Produto>(sql, new { idProduto = id, descricaoProduto = "%" + desricao + "%" });
            return retorno;
        }
    }
}
