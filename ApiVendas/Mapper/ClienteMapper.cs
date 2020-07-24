using ApiVendas.Models;
using ApiVendas.Requests;
using ApiVendas.Responses;

namespace ApiVendas.Mapper
{
    public static class ClienteMapper
    {
        public static Cliente Mapper(ClienteRequest clienteRequset)
        {
            return new Cliente() { 
                Id = clienteRequset.Id,
                Nome = clienteRequset.Nome,
                Email = clienteRequset.Email,
                DT_Nascimento = clienteRequset.DT_Nascimento
            };
        }

        public static ClienteResponse Mapper(Cliente cliente)
        {
            return new ClienteResponse()
            {
                Id = cliente.Id.ToString(),
                Nome = cliente.Nome,
                Email = cliente.Email,
                DT_Nascimento = cliente.DT_Nascimento.ToString()
            };
        }
    }
}
