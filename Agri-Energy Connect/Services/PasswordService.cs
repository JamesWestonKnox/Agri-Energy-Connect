// Summary
//----------------------------------------------------
// Password service is used to create password hash values and verfiy them against inputted values
// Assistance provided by ChatGPT, OpenAI (2025). https://chat.openai.com
// ---------------------------------------------------

using Microsoft.AspNetCore.Identity;

namespace Agri_Energy_Connect.Services
{
    public class PasswordService
    {
        private readonly PasswordHasher<object> _hasher = new();

        public string HashPassword(string password)
        {
            return _hasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _hasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}

// ============================== End Of FILE ============================== //