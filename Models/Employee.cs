using System;
namespace ERP_Bicicleteria.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime Registration { get; set; }
        public string Role { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
