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

        public void Update(ContactEntity updateContact)
        {
            Name = Name != updateContact.Name ? updateContact.Name : Name;
            Surname = Surname != updateContact.Surname ? updateContact.Surname : Surname;
            Email = Email != updateContact.Email ? updateContact.Email : Email;
            PhoneNumber = PhoneNumber != updateContact.PhoneNumber ? updateContact.PhoneNumber : PhoneNumber;
            Category = Category != updateContact.Category ? updateContact.Category : Category;
            SubCategory = SubCategory != updateContact.SubCategory ? updateContact.SubCategory : SubCategory;
            DateOfBirth = DateOfBirth != updateContact.DateOfBirth ? updateContact.DateOfBirth : DateOfBirth;
        }
    }
}
