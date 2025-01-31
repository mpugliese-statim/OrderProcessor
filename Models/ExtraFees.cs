namespace OrderProcessor.Models
{
    public class ExtraFees
    {
        //public ExtraFeesArray ExtraFeesArray { get; set; } = default!;

        public string ExtraFeeId { get; set; } = default!;
        public int Quantity { get; set; } = default!;
        public double UnitPrice { get; set; } = default!;
    }
}
