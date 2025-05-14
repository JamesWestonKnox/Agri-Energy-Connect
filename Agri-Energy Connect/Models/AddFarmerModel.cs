// Summary
//----------------------------------------------------
//AddFarmerModel is used to collect user input for creating a new farmer
// Assistance provided by ChatGPT, OpenAI (2025). https://chat.openai.com
// ---------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect.Models
{
    public class AddFarmerModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
    }
}

// ============================== End Of FILE ============================== //