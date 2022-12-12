using ApiVenda.Models;

namespace ApiVenda.Repository.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Cliente>> BuscarTodosAsync();
        Task<Pedido> BuscarPorIdAsync(int id);
        Task<bool> DeletarPorIdAsync(int id);
        Task<bool> RegistrarAsync(Pedido cliente);
    }
}
