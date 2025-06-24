using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP_Bicicleteria.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Debe seleccionar un empleado.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un cliente.")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "La fecha del pedido es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        // Lista de detalles del pedido (productos y cantidades)
        public List<OrderDetailViewModel> OrderDetails { get; set; } = new List<OrderDetailViewModel>();
    }

    public class OrderDetailViewModel
    {
        [Required(ErrorMessage = "Debe seleccionar un producto.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        public int Quantity { get; set; }
    }
}