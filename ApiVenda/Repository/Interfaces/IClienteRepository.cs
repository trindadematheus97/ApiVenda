using ApiVenda.Models;

namespace ApiVenda.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> BuscarTodosAsync();
        Task<Cliente> BuscarPorIdAsync(int id);
        Task<bool> AtualizadoAsync(Cliente cliente);
        Task<bool> RegistrarAsync(Cliente cliente);
        Task<bool> DeletarPorIdAsync(int id);

    }
}
