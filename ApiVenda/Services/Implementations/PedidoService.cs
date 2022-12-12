using ApiVenda.Models;
using ApiVenda.Repository.Implementations;
using ApiVenda.Repository.Interfaces;
using ApiVenda.Services.Interfaces;

namespace ApiVenda.Services.Implementations
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<bool> AdicionarAsync(Pedido inputModel)
        {
            var pedido = new Pedido( inputModel.CodItem, inputModel.CodCliente);

            var pedidoAdicionado = await _pedidoRepository.RegistrarAsync(pedido);

            return true;
        }

        public async Task<Pedido> BuscarPorIdAsync(int id)
        {
            var pedido = await _pedidoRepository.BuscarPorIdAsync(id);

            if (pedido == null)
                return null;

            return pedido;
        }

        public async Task<IEnumerable<Cliente>> BuscarTodosAsync()
        {
               return await _pedidoRepository.BuscarTodosAsync();
            
        }

        public async Task<bool> DeletarAsync(int id)
        {
            bool pedido;

            pedido = await _pedidoRepository.DeletarPorIdAsync(id);

            if (pedido == false) return false;

            return true;
        }
    }
}
