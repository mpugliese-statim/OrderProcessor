namespace OrderProcessor.Models
{
    public class DeliveryAddress
    {
        public string DeliveryAddressLine1 { get; set; } = default!;
        
        public string DeliveryAddressLine2 { get; set; } = default!;

        public string? Company { get; set; }

        public string? City { get; set; }

        public string? DeliveryPostalCode { get; set; }

        public string? DeliveryStateProvince { get; set; }
    }
}
