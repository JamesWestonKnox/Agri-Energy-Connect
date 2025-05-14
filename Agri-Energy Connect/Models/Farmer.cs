// Summary
//----------------------------------------------------
//Farmer is used to represent the farmer entity
// Assistance provided by ChatGPT, OpenAI (2025). https://chat.openai.com
// ---------------------------------------------------

namespace Agri_Energy_Connect.Models
{
    public class Farmer
    {
        public int FarmerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}

// ============================== End Of FILE ============================== //