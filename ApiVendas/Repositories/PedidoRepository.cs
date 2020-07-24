using ApiVendas.Models;
using ApiVendas.Responses;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ApiVendas.Repositories
{
    public static class PedidoRepository
    {
        public static ReturnResponse Gravar(Pedido Pedido)
        {
            try
            {
                BaseRepository.Command(Pedido);
                return new ReturnResponse(200, "Pedido Cadastrado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao cadastrar erro:", ex.Message));
            }
        }
        public static ReturnResponse Atualizar(Pedido Pedido)
        {
            try
            {
                BaseRepository.Command(Pedido, true);
                return new ReturnResponse(200, "Pedido Atualizado com sucesso!");
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
                BaseRepository.Delete<Pedido>(id);
                return new ReturnResponse(200, "Pedido deletado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return new ReturnResponse(500, string.Format("Erro ao deletar erro:", ex.Message));
            }
        }
        public static List<Pedido> Buscar(int nrpedido = 0, int clienteId = 0)
        {
            string sql = @" select
                            p.NumeroPedido as Nr_Pedido,
                            p.Data,
                            p.Tipo,
                            p.id_cliente,
                            c.id,
                            c.Nome,
                            c.Email,
                            c.Dt_Nascimento
                            from pedido p
                            join Cliente c on p.id_cliente = c.id ";

            if (nrpedido > 0)
            {
                sql += " where numeroPedido = @Nrpedido";
            }

            if (clienteId > 0)
            {
                if (sql.Contains("where"))
                    sql += " and id_cliente = @Id_cliente";
                else
                    sql += " where id_cliente = @Id_cliente";
            }

            List<Pedido> orderDetail;
            using (var connection = new SqlConnection(BaseRepository.ConnectionString))
            {
                orderDetail = connection.Query<Pedido, Cliente, Pedido>(sql, map: mapPropriedades, splitOn: "id", param: new { Nrpedido = nrpedido, Id_cliente = clienteId }).ToList();
            }

            const string sqlItem = @"select*from pedidoitem where NumeroPedido = @NumeroPedido";

            foreach (var item in orderDetail)
            {
                using (var connection = new SqlConnection(BaseRepository.ConnectionString))
                {
                    item.Itens.AddRange(connection.Query<PedidoItem>(sqlItem, param: new { NumeroPedido = item.Nr_Pedido }).ToList());
                }
            }

            return orderDetail;
        }

        private static Pedido mapPropriedades(Pedido pedido, Cliente cliente)
        {
            pedido.Cliente = cliente;

            return pedido;
        }
    }
}
