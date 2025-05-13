using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect.Models
{
    public class AddProductModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
