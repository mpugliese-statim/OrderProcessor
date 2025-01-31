namespace OrderProcessor.Models
{
    public class DeliveryNotes
    {
        public string DeliveryNotesContent { get; set; } = default!;
        public string ReadyAt { get; set; } = default!;
        public string ReferenceNumber1 { get; set; } = default!;    
        public string ReferenceNumber2 { get; set; } = default!;
        public string ReferenceNumber3 { get; set; } = default!;
        public string Notes { get; set; } = default!;
        public string ServiceLevelId { get; set; } = default!;
        public double CollectOnDelivery { get; set; } = default!;
        public bool AllowPartialCollectOnDelivery { get; set; } = true;
        public bool RequireIdentityValidation { get; set; } = true;
        public int NumberOfPieces { get; set; } = default!;
        public int Weight { get; set; } = default!;
        public string VehicleTypeId { get; set; } = default!;
        public string WebhookUrl { get; set; } = default!;
    }
}
