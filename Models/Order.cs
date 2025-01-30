namespace OrderProcessor.Models
{
    public class Order
    {
        public string? AccountId { get; set; }

        public string? CallerInfo { get; set; }

        public PickupAddress? PickupAddress { get; set; }

        public PickupLocation? PickupLocation { get; set; }

        public PickupContactInfo? pickupContactInfo { get; set; }

        public PickupNotes? pickupNotes { get; set; }

        public DeliveryAddress? deliveryAddress { get; set; }

        public DeliveryLocation? deliveryLocation { get; set; }

        public DeliveryContactInfo? deliveryContactInfo { get; set; }

        public DeliveryNotes? deliveryNotes { get; set; }

        public Metadata? metadata { get; set; }

        public AttributeIds? attributeIds { get; set; }

        public ExtraFees? extraFees { get; set; }
    }
}
