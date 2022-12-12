using ApiVenda.Models;
using ApiVenda.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiVenda.Controllers
{
    [Route("api/produto")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _produtoService.BuscarTodosAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid(int id)
        {
            var produto = await _produtoService.BuscarPorIdAsync(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produtoDeletado = await _produtoService.DeletarAsync(id);

            if (produtoDeletado == false)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Produto inputModel, int id)
        {
            var produto = await _produtoService.BuscarPorIdAsync(id);
            var produtoAtualizado = await _produtoService.AtualizarAsync(inputModel, id);

            if (produtoAtualizado == false)
                return BadRequest();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto inputModel)
        {
            var produtoAdicionado = await _produtoService.AdicionarAsync(inputModel);

            if (produtoAdicionado == false)
                return BadRequest();

            return Ok();
        }
    }
}

