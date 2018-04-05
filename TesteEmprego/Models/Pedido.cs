using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace TesteEmprego.Models
{
    public class Pedido
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]                            
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime Data { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<PedidoItem> Itens { get; set; }
    }
}
