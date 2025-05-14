// Summary
//----------------------------------------------------
//LoginModel is used to collect user input for logging in
// Assistance provided by ChatGPT, OpenAI (2025). https://chat.openai.com
// ---------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

// ============================== End Of FILE ============================== //