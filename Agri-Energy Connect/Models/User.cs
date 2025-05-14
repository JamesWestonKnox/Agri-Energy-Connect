// Summary
//----------------------------------------------------
//User is used to represent the User entity
// Assistance provided by ChatGPT, OpenAI (2025). https://chat.openai.com
// ---------------------------------------------------

namespace Agri_Energy_Connect.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}

// ============================== End Of FILE ============================== //
