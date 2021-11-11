using System;

namespace ProfileManager.Models
{
    public class Document
    {
        public User User { get; set; }
        public string UserId { get; set; }
        public string DocumentId { get; set; } = Guid.NewGuid().ToString();
        public string DocumentName { get; set; }
        public string DocumentURL { get; set; }
        public string PublicId { get; set; }
        public DateTime DateUploaded { get; set; } = DateTime.Now;

    }
}
