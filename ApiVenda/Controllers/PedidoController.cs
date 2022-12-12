using ApiVenda.Models;
using ApiVenda.Services.Implementations;
using ApiVenda.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiVenda.Controllers
{
    [Route("api/pedido")]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService clienteService)
        {
            _pedidoService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _pedidoService.BuscarTodosAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoService.BuscarPorIdAsync(id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pedidoDeletado = await _pedidoService.DeletarAsync(id);

            if (pedidoDeletado == false)
                return BadRequest();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pedido inputModel)
        {
            var pedidoAdicionado = await _pedidoService.AdicionarAsync(inputModel);

            if (pedidoAdicionado == false)
                return BadRequest();

            return Ok();
        }
    }
}