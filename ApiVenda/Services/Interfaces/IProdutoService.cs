using ApiVenda.Models;

namespace ApiVenda.Services.Interfaces
{
    public interface IProdutoService
    {
         Task<IEnumerable<Produto>> BuscarTodosAsync();
         Task<Produto> BuscarPorIdAsync(int id);
         Task<bool> DeletarAsync(int id);
         Task<bool> AtualizarAsync(Produto inputModel, int id);
         Task<bool> AdicionarAsync(Produto inputModel);
    }
}
