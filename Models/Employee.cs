using ERP_Bicicleteria.Models;
using System.ComponentModel.DataAnnotations;


namespace ERP_Bicicleteria.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del empleado.")]
        public string EmployeeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe ingresar la fecha de registro.")]
        [DataType(DataType.Date)]
        public DateTime Registration { get; set; }

        [Required(ErrorMessage = "Debe ingresar el rol del empleado.")]
        public string Role { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "El salario debe ser un valor positivo.")]
        public decimal Salary { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}



