using System.ComponentModel.DataAnnotations;

namespace L02P02_2020CM606_2023LG651.Models
{
    public class autores
    {
        [Key]
        public int id { get; set; }
        public string autor { get; set; }
    }
}