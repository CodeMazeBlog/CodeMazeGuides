namespace OptimisticVsPessimisticLocking.Entities;

using System.ComponentModel.DataAnnotations;

public class WorkItemWithRowVersion
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }

    public DateTime DueDate { get; set; }

    public string AssignedTo { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}