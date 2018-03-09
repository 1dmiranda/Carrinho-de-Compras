using System.Collections.Generic;

namespace TesteEmprego.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        public ICollection<Pedido> Pedido { get; set; }
    }
}
