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
    public class PedidoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<PedidoResponse>> Get()
        {
            var produtos = PedidoRepository.Buscar().Select(p => PedidoMapper.Mapper(p));

            return produtos.ToList();

        }

        [HttpGet("{nr_pedido}")]
        public ActionResult<PedidoResponse> Get(int nr_pedido)
        {
            var produto = PedidoMapper.Mapper(PedidoRepository.Buscar(nr_pedido).FirstOrDefault());

            return produto;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] PedidoRequest request)
        {
            var produto = PedidoMapper.Mapper(request);

            return PedidoRepository.Gravar(produto);
        }

        [HttpPut]
        public ActionResult<ReturnResponse> Put([FromBody] PedidoRequest request)
        {
            var produto = PedidoMapper.Mapper(request);
            return PedidoRepository.Atualizar(produto);
        }

        [HttpDelete("{id}")]
        public ActionResult<ReturnResponse> Delete(int id)
        {
            return PedidoRepository.Delete(id);
        }
    }
}