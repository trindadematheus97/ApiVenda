using ApiVenda.Models;
using ApiVenda.Repository.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace ApiVenda.Repository.Implementations
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly string _connectionString;
        public PedidoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        

        public async Task<Pedido> BuscarPorIdAsync(int id)
        {
            Pedido pedidos = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT  DtPedido, CodItem FROM Pedido WHERE CodCliente = @Id;";

                pedidos = await connection.QueryFirstOrDefaultAsync<Pedido>(sql, new { Id = id });
            }

            return pedidos;

        }         
        

        public async Task<IEnumerable<Cliente>> BuscarTodosAsync()
        {
            IEnumerable<Cliente> listaPedidos;
            using (var connection = new SqlConnection(_connectionString))
            {
                listaPedidos = await connection.QueryAsync<Cliente, Pedido, Cliente>(
                    @"SELECT DISTINCT
                        cli.Nome,
                        cli.Email,
                        cli.CodCliente,
                        pdi.CodPedido,
                        pdi.DtPedido,
                        pdi.CodCliente,
                        pdi.CodItem                             
                      FROM Cliente cli
                      INNER JOIN Pedido pdi
                      ON pdi.CodCliente = cli.CodCliente",
                    map: (cliente, pedido) =>
                    {
                        cliente.Pedidos = pedido;
                        return cliente;
                    },
                    splitOn: "CodPedido"); ;
            }

            return listaPedidos;
        }

        public async Task<bool> DeletarPorIdAsync(int id)
        {
            
                try
                {
                    int pedido = 0;
                    using (var connection = new SqlConnection(_connectionString))
                    {
                        string sql = "DELETE FROM Pedido WHERE CodPedido = @Id";

                    pedido = await connection.ExecuteAsync(sql, new { Id = id });

                    }
                    return pedido > 0;
                }
                catch (SqlException)
                {
                    return false;
                }
            
        }

        public async Task<bool> RegistrarAsync(Pedido pedido)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string sql = @"INSERT INTO PEDIDO(CodCliente, CodItem)
                            VALUES (@CodCliente, @CodItem)";

                    var id = await connection.ExecuteAsync(sql,
                        new
                        {
                            CodCliente = pedido.CodCliente,
                            CodItem = pedido.CodItem
                        });
                }

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
