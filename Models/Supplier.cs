using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ERP_Bicicleteria.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        [Display(Name = "Empresa")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Contacto")]

        public string ContactName { get; set; } = string.Empty;
        [Display(Name = "Dirección")]

        public string Address { get; set; } = string.Empty;
        [Display(Name = "Localidad/Ciudad")]

        public string City { get; set; } = string.Empty;
        [Display(Name = "Telefono/Celular Contacto")]

        public string Phone { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
