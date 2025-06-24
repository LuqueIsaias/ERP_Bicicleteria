using ERP_Bicicleteria.Data;
using ERP_Bicicleteria.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_Bicicleteria.Services
{
    public class OrderDetailService
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Añadir detalles de la orden
        public void AddOrderDetails(Order order, List<OrderDetailViewModel> details)
        {
            foreach (var detail in details)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    ProductId = detail.ProductId,
                    Quantity = detail.Quantity
                };
                _context.OrderDetail.Add(orderDetail);
            }
        }

        // Actualizar detalles de la orden (si es necesario)
       /* public void UpdateOrderDetails(Order order, List<OrderDetailViewModel> details)
        {
            // Eliminar detalles existentes de la orden
            _context.OrderDetails.RemoveRange(order.OrderDetails);

            // Añadir nuevos detalles
            AddOrderDetails(order, details);
        }*/
    }
}
