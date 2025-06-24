using System.ComponentModel.DataAnnotations;


namespace ERP_Bicicleteria.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Phone]
        [Display(Name = "Teléfono")]
        public string Cellphone { get; set; } = string.Empty;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}

