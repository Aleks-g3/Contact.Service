using Contact.Service.Core.Enums;

namespace Contact.Service.Core.Models
{
    public class ContactEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Category Category { get; set; }
        public string SubCategory { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
