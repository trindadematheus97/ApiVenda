namespace ApiVenda.Models
{
    public class Produto
    {
        public int CodProduto { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public decimal Valor { get; set; }

        public Produto()
        {

        }
        public Produto(string nome, decimal valor, int estoque)
        {
            Nome = nome;
            Valor = valor;
            Estoque = estoque;
        }

        public void Atualizar(string nome, int estoque, decimal valor)
        {
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
        }

    }
}
