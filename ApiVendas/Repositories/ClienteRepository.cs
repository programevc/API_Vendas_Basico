using ApiVendas.Models;
using ApiVendas.Responses;
using System.Collections.Generic;

namespace ApiVendas.Repositories
{
    public static class ClienteRepository
    {
        public static ReturnResponse Gravar(Cliente Cliente)
        {
            try
            {
                BaseRepository.Command(Cliente);
                return new ReturnResponse(200, "Cliente Cadastrado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao cadastrar erro:", ex.Message));
            }
        }
        public static ReturnResponse Atualizar(Cliente Cliente)
        {
            try
            {
                BaseRepository.Command(Cliente, true);
                return new ReturnResponse(200, "Cliente atualizado com sucesso!");
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
                BaseRepository.Delete<Cliente>(id);
                return new ReturnResponse(200, "Cliente deletado com sucesso!");

            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao deletar erro:", ex.Message));
            }
        }
        public static List<Cliente> Buscar(int id = 0, string nome = "")
        {
            string sql = "select * from Cliente";

            if (id > 0)
            {
                sql += " where id = @idCliente";
            }

            if (!string.IsNullOrEmpty(nome))
            {
                if (sql.Contains("where"))
                    sql += " and nome like @nomeCliente";
                else
                    sql += " where nome like @nomeCliente";
            }

            var retorno = BaseRepository.QuerySql<Cliente>(sql, new { idCliente = id, nomeCliente = "%" + nome + "%" });
            return retorno;
        }
    }
}
