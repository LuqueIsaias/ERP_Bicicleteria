using System;
namespace ERP_Bicicleteria.Models
{
    public class Order
    { 
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
