namespace OrderProcessor.Models
{
    public class WorkflowSteps
    {
        public string StepId { get; set; } = default!;
        public string? SelectionStepId { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
