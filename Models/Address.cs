namespace OrderProcessor.Models
{
    public class Address
    {
        //public AddressArray[] AddressArray { get; set; } = default!;
        public string AddressLine1 { get; set; } = default!;
        public string AddressLine2 { get; set; } = default!;
        public string? Company { get; set; }
        public string City { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string StateProvince { get; set; } = default!;
    }
}
