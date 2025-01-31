namespace OrderProcessor.Models
{
    public class Workflows
    {
        public string Id { get; set; } = default!;
        public int WorkflowType { get; set; } = default!;
        public WorkflowSteps WorkflowSteps { get; set; } = default!;
    }
}
