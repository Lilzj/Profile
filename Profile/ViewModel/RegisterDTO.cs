using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ProfileManager.ViewModel
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        public List<IFormFile> Documents { get; set; } = new List<IFormFile>();

    }
}
