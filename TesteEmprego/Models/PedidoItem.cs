using System.ComponentModel.DataAnnotations;

namespace TesteEmprego.Models
{
    public class PedidoItem
    {
        [Key]
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        [Key]
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}