using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L02P02_2020CM606_2023LG651.Models
{
    public class pedido_detalle
    {
        [Key]
        public int id { get; set; }
        public int id_pedido { get; set; }
        public int id_libro { get; set; }
        public DateTime created_at { get; set; }
        
        [ForeignKey("id_pedido")]
        public virtual pedido_encabezado PedidoEncabezado { get; set; }
        
        [ForeignKey("id_libro")]
        public virtual libros Libro { get; set; }
    }
}