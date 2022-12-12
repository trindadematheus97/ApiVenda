namespace ApiVenda.Models
{
    public class Cliente
    {
        public int CodCliente { get; set; }
        public int Pedido { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DtNascimento { get; set; }
        public Pedido Pedidos { get; set; }

        public Cliente()
        {

        }
        public Cliente( string nome, string email, DateTime dtNascimento)
        {
            Nome = nome;
            Email = email;
            DtNascimento = dtNascimento;
        }

        public void Atualizar(string nome, string email, DateTime dtNascimento, int pedido)
        {
            Nome = nome;
            Email = email;
            DtNascimento = dtNascimento;
            Pedido = pedido;
         }
    } 
}
