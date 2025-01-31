namespace OrderProcessor.Models
{
    public class OrderPayoutDelivery
    {   
        public int CalculationType { get; set; } = default!;
        public decimal? CommissionPercentage { get; set; }
        public decimal? PredefinedPayoutValue { get; set; }
        public string? FixedPayoutScheduleId { get; set; }
    }
}
