using ApiVenda.Models;
using ApiVenda.Repository.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace ApiVenda.Repository.Implementations
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _connectionString;
        public ProdutoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Produto> BuscarPorIdAsync(int id)
        {
            Produto produto = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT CodProduto, Nome, Valor, Estoque FROM Produto WHERE CodProduto = @Id";

                produto = await connection.QueryFirstOrDefaultAsync<Produto>(sql, new { Id = id });
            }

            return produto;
        }

        public async Task<IEnumerable<Produto>> BuscarTodosAsync()
        {
            IEnumerable<Produto> produtos;

            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT  CodCliente, Nome, Estoque, Valor FROM Produto";

                produtos = await connection.QueryAsync<Produto>(sql);
            }

            return produtos;
        }

        public async Task<bool> DeletarPorIdAsync(int id)
        {
            try
            {
                int produto = 0;
                using (var connection = new SqlConnection(_connectionString))
                {
                    string sql = "DELETE FROM Produto WHERE CodProduto = @Id";

                    produto = await connection.ExecuteAsync(sql, new { Id = id });

                }
                return produto > 0 ;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public async Task<bool> RegistrarAsync(Produto produto)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string sql = @"INSERT INTO PRODUTO(Nome, Estoque, Valor)
                            VALUES (@Nome, @Estoque, @Valor)";

                    var id = await connection.ExecuteAsync(sql,
                        new
                        {
                            Nome = produto.Nome,
                            Estoque = produto.Estoque,
                            Valor = produto.Valor
                        });
                }

                return true;
            }
            catch (SqlException)
            {
                return false;
            }

        }

        public async Task<bool> AtualizadoAsync(Produto produto)
        {
            try
            {
                int result = 0;
                using (var connection = new SqlConnection(_connectionString))
                {
                    string sql = @"
                        UPDATE Produto SET
                            Nome = @Nome,
                            Estoque = @Estoque,
                            Valor = @Valor
                        WHERE 
                            Codproduto = @CodProduto";

                    var parametros = new DynamicParameters();
                    parametros.Add("CodProduto", produto.CodProduto);
                    parametros.Add("Estoque", produto.Estoque);
                    parametros.Add("Valor", produto.Valor);
                    parametros.Add("Nome", produto.Nome);

                    result = await connection.ExecuteAsync(sql, parametros);
                }

                return result == 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}

