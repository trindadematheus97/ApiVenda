using ApiVenda.Models;

namespace ApiVenda.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> BuscarTodosAsync();
        Task<Cliente> BuscarPorIdAsync(int id);
        Task<bool> AtualizarAsync(Cliente inputModel, int id);
        Task<bool> AdicionarAsync(Cliente inputModel);
        Task<bool> DeletarAsync(int id);
    }
}
