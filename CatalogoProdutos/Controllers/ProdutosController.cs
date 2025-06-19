using CatalogoProdutos.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CatalogoProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoDomain _produtoDomain;

        public ProdutosController()
        {
            _produtoDomain = new ProdutoDomain();
        }

        [HttpPost]
        public IActionResult Inserir(InserirProdutoDTO dadosDaInsercao)
        {
            try
            {
                _produtoDomain.Inserir(dadosDaInsercao);

                return Ok("Produto inserido com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Alterar([FromRoute] int id, [FromBody] EditarProdutoDTO dadosDaAlteracao)
        {
            try
            {
                _produtoDomain.Alterar(id, dadosDaAlteracao);

                return Ok("Produto alterado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public IActionResult BuscarProdutos()
        {
            try
            {
                var produtos = _produtoDomain.BuscarProduto();

                return Ok(produtos);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("/api/[controller]/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var produtos = _produtoDomain.BuscarPorId(id);

                return Ok(produtos);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("/api/[Controller]/Inativar{id}")]
        public IActionResult Inativar([FromRoute] int id)
        {
            try
            {
                _produtoDomain.Inativar(id);

                return Ok("Produto inativado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
