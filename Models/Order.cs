using ERP_Bicicleteria.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ERP_Bicicleteria.Models;

public class Order
{
    public int OrderId { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public int ClientId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime OrderDate { get; set; }

    [ForeignKey("ClientId")]
    public Client? Client { get; set; }

    [ForeignKey("EmployeeId")]
    public Employee? Employee { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
