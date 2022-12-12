using ApiVenda.Models;
using ApiVenda.Repository.Interfaces;
using ApiVenda.Services.Interfaces;

namespace ApiVenda.Services.Implementations
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async  Task<bool> AdicionarAsync(Produto inputModel)
        {
            var produto = new Produto(inputModel.Nome, inputModel.Valor, inputModel.Estoque);

            var produtoAdicionado = await _produtoRepository.RegistrarAsync(inputModel);

            return true;
        }

        public async  Task<bool> AtualizarAsync(Produto inputModel, int id)
        {
            var produto = await _produtoRepository.BuscarPorIdAsync(id);

            if (produto == null)
                return false;

            produto.Atualizar(inputModel.Nome, inputModel.Estoque, inputModel.Valor);

            var produtoAtualizado = await _produtoRepository.AtualizadoAsync(produto);

            if (produtoAtualizado)
                return true;

            return false;
        }

        public async Task<Produto> BuscarPorIdAsync(int id)
        {
            var produto = await _produtoRepository.BuscarPorIdAsync(id);

            if (produto == null)
                return null;        

            return produto;
        }

        public async Task<IEnumerable<Produto>> BuscarTodosAsync()
        {
            return await _produtoRepository.BuscarTodosAsync();
        }

        public async Task<bool> DeletarAsync(int id)
        {
            bool produto;

            produto = await _produtoRepository.DeletarPorIdAsync(id);

            if (produto == false) return false;

            return true;
        }
    }
}
