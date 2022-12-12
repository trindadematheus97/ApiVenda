using ApiVenda.Models;
using ApiVenda.Repository.Implementations;
using ApiVenda.Repository.Interfaces;
using ApiVenda.Services.Interfaces;

namespace ApiVenda.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<IEnumerable<Cliente>> BuscarTodosAsync()
        {
            return await _clienteRepository.BuscarTodosAsync();
        }
        public async Task<Cliente> BuscarPorIdAsync(int id)
        {
            var cliente = await _clienteRepository.BuscarPorIdAsync(id);

            if (cliente == null)
                return null;

            return cliente;
        }
        public async Task<bool> AtualizarAsync(Cliente inputModel, int id)
        {
           var cliente = await _clienteRepository.BuscarPorIdAsync(id);

            if (cliente == null)
                return false;

            cliente.Atualizar(inputModel.Nome, inputModel.Email, inputModel.DtNascimento, inputModel.Pedido);

            var clienteAtualizado = await _clienteRepository.AtualizadoAsync(cliente);

            if (clienteAtualizado)
                return true;

            return false;
        }

        public async Task<bool> AdicionarAsync(Cliente inputModel)
        {
            var cliente = new Cliente(inputModel.Nome, inputModel.Email, inputModel.DtNascimento);

            var clienteAdicionado = await _clienteRepository.RegistrarAsync(cliente);

            return true;
        }
        public async Task<bool> DeletarAsync(int id)
        {
            bool cliente;

            cliente = await _clienteRepository.DeletarPorIdAsync(id);

            if (cliente == false) return false;

            return true;
        }
    }
}
