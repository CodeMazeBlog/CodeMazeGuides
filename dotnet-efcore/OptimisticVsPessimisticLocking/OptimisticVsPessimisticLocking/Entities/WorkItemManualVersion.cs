namespace OptimisticVsPessimisticLocking.Entities;

using System.ComponentModel.DataAnnotations;

public class WorkItemManualVersion
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }

    public DateTime DueDate { get; set; }

    public string AssignedTo { get; set; }

    [ConcurrencyCheck]
    public long Version { get; set; }
}