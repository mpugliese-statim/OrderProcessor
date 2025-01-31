namespace OrderProcessor.Models
{
    public class ItemsArray
    {
        public string? BarcodeTemplate { get; set; }
        public string ParcelTypeId { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Weight { get; set; } = default!;
        public int Height { get; set; } = default!;
        public int Length { get; set; } = default!;
        public int Width { get; set; } = default!;
        public UserFields[] UserFields { get; set; } = default!;
    }
}
