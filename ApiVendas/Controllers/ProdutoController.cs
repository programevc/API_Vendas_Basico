using ApiVendas.Mapper;
using ApiVendas.Models;
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
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProdutoResponse>> Get()
        {
            var produtos = ProdutoRepository.Buscar().Select(p => ProdutoMapper.Mapper(p));

            return produtos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoResponse> Get(int id)
        {
            var produto = ProdutoMapper.Mapper(ProdutoRepository.Buscar(id).FirstOrDefault());

            return produto;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] ProdutoRequest request)
        {
            var produto = ProdutoMapper.Mapper(request);

            return ProdutoRepository.Gravar(produto);
        }

        [HttpPut]
        public ActionResult<ReturnResponse> Put([FromBody] ProdutoRequest request)
        {
            var produto = ProdutoMapper.Mapper(request);
            return ProdutoRepository.Atualizar(produto);
        }

        [HttpDelete("{id}")]
        public ActionResult<ReturnResponse> Delete(int id)
        {
            return ProdutoRepository.Delete(id);
        }
    }
}