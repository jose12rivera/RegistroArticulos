using System.ComponentModel.DataAnnotations;

namespace RegistroArticulos.Models
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        [Required(ErrorMessage ="Intentar de nuevo")]
        public string?Nombre { get; set; }
        [Required(ErrorMessage = "Intentar de nuevo")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Intentar de nuevo")]
        public decimal? Precio { get; set; }
    }
}
