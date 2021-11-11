using ProfileManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileManager.ViewModel
{
    public class ProfileViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string TransactionNumber { get; set; }
        public List<Document> Documents { get; set; }

        public ProfileViewModel()
        {
            Documents = new List<Document>();
        }
    }
}
