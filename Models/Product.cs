using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP_Bicicleteria.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Producto")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Descripción del Producto")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Precio"), DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int ReorderLevel { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un proveedor.")]
        [Display(Name = "Proveedor")]
        public int SupplierId { get; set; }


        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }
    }

}

