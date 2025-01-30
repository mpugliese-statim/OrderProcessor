namespace OrderProcessor.Models
{
    public class ExtraFees
    {
        // may need to use an array here...
        public string ExtraFeeId { get; set; } = default!;
        public int Quantity { get; set; } = default!;
        public decimal UnitPrice { get; set; } = default!;
    }
}
