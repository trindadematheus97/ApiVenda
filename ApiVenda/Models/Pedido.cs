namespace ApiVenda.Models
{
    public class Pedido
    {
        public int CodPedido { get; set; }
        public DateTime DtPedido { get; set; }
        public int CodCliente { get; set; }
        public int CodItem { get; set; }
        public Cliente Cliente { get; set; }

        public Pedido()
        {

        }
        public Pedido(int codCliente, int codItem)
        {
            CodCliente = codCliente;
            CodItem = codItem;
        }
    }
}
