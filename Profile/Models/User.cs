using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Profile.Models
{
    public class User : IdentityUser
    {
        public string UserId { get; set; } = new Guid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
