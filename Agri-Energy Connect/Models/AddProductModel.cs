// Summary
//----------------------------------------------------
//AddProductModel is used to collect user input for creating a new product
// Assistance provided by ChatGPT, OpenAI (2025). https://chat.openai.com
// ---------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect.Models
{
    public class AddProductModel
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "A description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter a production date.")]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public double Price { get; set; }
    }
}

// ============================== End Of FILE ============================== //