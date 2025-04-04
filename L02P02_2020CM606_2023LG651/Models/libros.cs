using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L02P02_2020CM606_2023LG651.Models
{
    public class libros
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string url_imagen { get; set; }
        public int id_autor { get; set; }
        public int id_categoria { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal precio { get; set; }
        public char estado { get; set; }
        
        [ForeignKey("id_autor")]
        public virtual autores Autor { get; set; }
        
        [ForeignKey("id_categoria")]
        public virtual categorias Categoria { get; set; }
    }
}