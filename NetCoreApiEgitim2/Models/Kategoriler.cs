using System.ComponentModel.DataAnnotations;

namespace NetCoreApiEgitim2.Models
{
    public class Kategoriler
    {
        [Key]
        public int id { get; set; }
        public string? ad { get; set; }
        public bool? aktif { get; set; }
    }
}
