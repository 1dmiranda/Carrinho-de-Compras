using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteEmprego.Models
{
    public class Produto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}