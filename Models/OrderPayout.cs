namespace OrderProcessor.Models
{
    public class OrderPayout
    {
        public decimal? PredefinedPayoutValue { get; set; }
        public string? DriverCommissionCalculationType { get; set; }
        public OrderPayoutDelivery[] OrderPayoutDelivery { get; set; } = default!;
        public OrderPayoutFuelSurcharge[] OrderPayoutFuelSurcharge { get; set; } = default!;
        public OrderPayoutExtraFees[] OrderPayoutExtraFees { get; set; } = default!;
        public bool GenerateProofOfDeliveryOnDelivery { get; set; } = false;
    }
}
