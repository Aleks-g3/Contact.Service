namespace Contact.Service.API.Entities
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
