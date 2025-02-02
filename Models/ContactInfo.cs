namespace OrderProcessor.Models
{
    public class ContactInfo
    {
        //public ContactInfoArray[] contactInfoArray { get; set; } = default!;
        public string? Id { get; set; }
        public string Name { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Language { get; set; } = default!;
    }
}
