using ApiVenda.Models;

namespace ApiVenda.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        Task<bool> RegistrarAsync(Produto produto);
        Task<bool> AtualizadoAsync(Produto produto);
        Task<IEnumerable<Produto>> BuscarTodosAsync();
        Task<Produto> BuscarPorIdAsync(int id);
        Task<bool> DeletarPorIdAsync(int id);
    }
}
