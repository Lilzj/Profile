using System;

namespace Profile.Models
{
    public class Document
    {
        public User UserId { get; set; }
        public int DocumentID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentURL { get; set; }
        public string PublicId { get; set; }
        public DateTime DateUploaded { get; set; } = DateTime.Now;

    }
}
