using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L02P02_2020CM606_2023LG651.Models
{
    public class pedido_encabezado
    {
        [Key]
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int cantidad_libros { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal total { get; set; }
        
        [ForeignKey("id_cliente")]
        public virtual clientes Cliente { get; set; }
    }
}