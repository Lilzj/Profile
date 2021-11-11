using System;
using System.Collections.Generic;

namespace ProfileManager.Models
{
    public class User
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string TransactionNumber { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public List<Document> Documents { get; set; }


        public User()
        {
            Documents = new List<Document>();
        }

    }


}
