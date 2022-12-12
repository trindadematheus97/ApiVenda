using ApiVenda.Models;
using ApiVenda.Services.Implementations;
using ApiVenda.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ApiVenda.Controllers
{
    [Route("api/cliente")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _clienteService.BuscarTodosAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteService.BuscarPorIdAsync(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Cliente inputModel, int id)
        {
            var cliente = await _clienteService.BuscarPorIdAsync(id);
            var clienteAtualizado = await _clienteService.AtualizarAsync(inputModel, id);

            if (clienteAtualizado == false)
                return BadRequest();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente inputModel)
        {
            var clienteAdicionado = await _clienteService.AdicionarAsync(inputModel);

            if (clienteAdicionado == false)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var clienteDeletado = await _clienteService.DeletarAsync(id);

            if (clienteDeletado == false)
                return BadRequest();

            return Ok();
        }
    }
}
