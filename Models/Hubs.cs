namespace OrderProcessor.Models
{
    public class Hubs
    {
        public string? AddressId { get; set; }

        public Address Address { get; set; } = default!;
        public Location Location { get; set; } = default!;
        public ContactInfo ContactInfo { get; set; } = default!;
        public int LoadTimeInMinutes { get; set; } = default!;
        public string Notes { get; set; } = default!;
        public string SegmentOverrideInfos { get; set; } = default!;
    }
}
