using ApiVendas.Mapper;
using ApiVendas.Repositories;
using ApiVendas.Requests;
using ApiVendas.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ClienteResponse>> Get()
        {
            var cliente = ClienteRepository.Buscar().Select(p => ClienteMapper.Mapper(p));

            return cliente.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteResponse> Get(int id)
        {
            var cliente = ClienteMapper.Mapper(ClienteRepository.Buscar(id).FirstOrDefault());

            return cliente;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] ClienteRequest request)
        {
            var cliente = ClienteMapper.Mapper(request);

            return ClienteRepository.Gravar(cliente);
        }

        [HttpPut]
        public ActionResult<ReturnResponse> Put([FromBody] ClienteRequest request)
        {
            var Cliente = ClienteMapper.Mapper(request);
            return ClienteRepository.Atualizar(Cliente);
        }

        [HttpDelete("{id}")]
        public ActionResult<ReturnResponse> Delete(int id)
        {
            return ClienteRepository.Delete(id);
        }
    }
}