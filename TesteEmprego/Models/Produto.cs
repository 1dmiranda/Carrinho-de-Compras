using System.Collections.Generic;

namespace TesteEmprego.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }

        public ICollection<Pedido> Pedido { get; set; }
    }
}
