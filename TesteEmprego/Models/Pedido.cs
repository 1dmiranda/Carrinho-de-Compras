using System;

namespace TesteEmprego.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public DateTime PedidoData { get; set; }
        public decimal ValorTotal { get; set; }

        public Usuario Usuario { get; set; }
        public Produto Produto { get; set; }
    }
}
