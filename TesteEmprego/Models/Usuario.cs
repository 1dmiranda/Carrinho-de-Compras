using System.Collections;
using System.Collections.Generic;

namespace TesteEmprego.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

        public Pedido Pedido { get; set; }
    }
}