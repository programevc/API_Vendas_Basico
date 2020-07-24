using ApiVendas.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ApiVendas.Repositories
{
    public static class BaseRepository
    {
        public const string ConnectionString = "Server=192.168.0.5\\sqlexpress;Database=vendas;Trusted_Connection=True;";
        public static List<T> QuerySql<T>(string sql, object parameter = null)
        {
            List<T> orderDetail;
            using (var connection = new SqlConnection(ConnectionString))
            {
                orderDetail = connection.Query<T>(sql, parameter).ToList();
            }

            return orderDetail;
        }

        public static void Delete<T>(int id) where T : BaseModel
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var tabela = typeof(T).Name;
                string query = $"select * from {tabela} where {BuscaColunaChave(tabela)} = @id";
                var objeto = connection.Query<T>(query, new { id });
                connection.Delete(objeto);
            }
        }

        public static void Command<T>(T objeto, bool editar = false, object parameter = null) where T : BaseModel
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                if (editar)
                    connection.Update(objeto);
                else
                    connection.Insert(objeto);
            }
        }

        private static string BuscaColunaChave(string nomeTabela)
        {
            string query = @"SELECT Col.Column_Name from 
                             INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab, 
                             INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col 
                             WHERE 
                             Col.Constraint_Name = Tab.Constraint_Name
                             AND Col.Table_Name = Tab.Table_Name
                             AND Constraint_Type = 'PRIMARY KEY'
                             AND Col.Table_Name = @tablename";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<string>(query, new { tablename = nomeTabela }).FirstOrDefault();
            }
        }
    }
}