using System.ComponentModel.DataAnnotations;

namespace ERP_Bicicleteria.Models
{
    public class Product
    {
        
            public int Id { get; set; }

            [Display(Name = "Nombre del Producto")]
            public string Name { get; set; }

            [Display(Name = "Descripción del Producto")]
            public string Description { get; set; }

            [Display(Name = "Precio"),DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
            public decimal Price { get; set; }

            [Display(Name = "Código de Proveedor")]
            public string SupplierCode { get; set; }
     }
}

