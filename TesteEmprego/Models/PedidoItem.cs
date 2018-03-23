namespace TesteEmprego.Models
{
    public class PedidoItem
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

    }
}