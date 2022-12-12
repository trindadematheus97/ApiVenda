using ApiVenda.Models;

namespace ApiVenda.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<Cliente>> BuscarTodosAsync();
        Task<Pedido> BuscarPorIdAsync(int id);
        Task<bool> DeletarAsync(int id);
        Task<bool> AdicionarAsync(Pedido inputModel);
    }
}
