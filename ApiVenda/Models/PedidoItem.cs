namespace ApiVenda.Models
{
    public class PedidoItem
    {
        public int CodItem { get; set; }
        public int Quantidade { get; set; }
        public int codProduto { get; set; }

        public void Atualizar(int quantidade)
        {
            Quantidade = quantidade;
        }
    }
}
