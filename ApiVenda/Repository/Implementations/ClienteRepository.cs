using ApiVenda.Models;
using ApiVenda.Repository.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace ApiVenda.Repository.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;
        public ClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Cliente>BuscarPorIdAsync(int id)
        {
            Cliente cliente = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT  CodCliente, Nome, Pedido, Email, DtNascimento FROM Cliente WHERE CodCliente = @Id;";

                cliente = await connection.QueryFirstOrDefaultAsync<Cliente>(sql, new { Id = id });
            }

            return cliente;
        }

        public async Task<IEnumerable<Cliente>> BuscarTodosAsync()
        {
            IEnumerable<Cliente> clientes;

            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT  Nome, Pedido, Email, DtNascimento FROM Cliente";

                clientes = await connection.QueryAsync<Cliente>(sql);
            }

            return clientes;
        }
        public async Task<bool> AtualizadoAsync(Cliente cliente)
        {
            try
            {
                var result = 0;
                using (var connection = new SqlConnection(_connectionString))
                {
                    string sql = @"
                        UPDATE Cliente SET
                            Nome = @Nome,
                            Email = @Email,
                            DtNascimento = @DtNascimento                          
                        WHERE 
                            CodCliente = @CodCliente";

                    var parametros = new DynamicParameters();
                    parametros.Add("CodCliente", cliente.CodCliente);
                    parametros.Add("Nome", cliente.Nome);
                    parametros.Add("Email", cliente.Email);
                    parametros.Add("DtNascimento", cliente.DtNascimento);
                    parametros.Add("Pedido", cliente.Pedido);

                    result = await connection.ExecuteAsync(sql, parametros);

                }
                    return result > 0;
                
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public async Task<bool> RegistrarAsync(Cliente cliente)
        {
                try
                {
                    using (var connection = new SqlConnection(_connectionString))
                    {
                        string sql = @"INSERT INTO CLIENTE(Nome, Email, DtNascimento)
                            VALUES (@Nome, @Email, @DtNascimento)";

                    var id = await connection.ExecuteAsync(sql,
                        new
                        {
                            Nome = cliente.Nome,
                            Email = cliente.Email,
                            DtNascimento = cliente.DtNascimento
                        });
                    }

                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }

         }
        public async Task<bool> DeletarPorIdAsync(int id)
        {
            try
            {
                int produto = 0;
                using (var connection = new SqlConnection(_connectionString))
                {
                    string sql = "DELETE FROM Cliente WHERE CodCliente = @Id";

                    produto = await connection.ExecuteAsync(sql, new { Id = id });

                }
                return produto > 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
 }

