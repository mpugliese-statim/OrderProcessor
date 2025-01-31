namespace OrderProcessor.Models
{
    public class Order
    {
        public string? AccountId { get; set; }

        public ICollection<CallerInfo> CallerInfo { get; set; } = new List<CallerInfo>();

        public ICollection<PickupAddress> PickupAddress { get; set; } = new List<PickupAddress>();

        public ICollection<PickupLocation> PickupLocation { get; set; } = new List<PickupLocation>();

        public ICollection<PickupContactInfo> PickupContactInfo { get; set; } = new List<PickupContactInfo>();

        public ICollection<PickupNotes> PickupNotes { get; set; } = new List<PickupNotes>();

        public ICollection<DeliveryAddress> DeliveryAddress { get; set; } = new List<DeliveryAddress>();

        public ICollection<DeliveryLocation> DeliveryLocation { get; set; } = new List<DeliveryLocation>();

        public ICollection<DeliveryContactInfo> DeliveryContactInfo { get; set; } = new List<DeliveryContactInfo>();

        public ICollection<DeliveryNotes> DeliveryNotes { get; set; } = new List<DeliveryNotes>();

        public ICollection<Metadata> Metadata { get; set; } = new List<Metadata>();

        //public ICollection<AttributeIds> AttributeIds { get; set; } = new List<AttributeIds>();
        public string[]? AttributeIds { get; set; } = new string[2];
        public ICollection<ExtraFees> ExtraFees { get; set; } = new List<ExtraFees>();

        public ICollection<Workflows> Workflows { get; set; } = new List<Workflows>();
        public ICollection<UserFields> UserFields { get; set; } = new List<UserFields>();
        public ICollection<Items> Items { get; set; } = new List<Items>();
        public ICollection<Hubs> Hubs { get; set; } = new List<Hubs>();
        public ICollection<OrderPayout> OrderPayout { get; set; } = new List<OrderPayout>();
    }
}
