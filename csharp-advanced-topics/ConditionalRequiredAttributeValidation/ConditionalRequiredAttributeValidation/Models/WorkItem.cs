using System.ComponentModel.DataAnnotations;
using ExpressiveAnnotations.Attributes;

namespace ConditionalRequiredAttributeValidation.Models;

public class WorkItem
{
    public long Id { get; set; }

    [Required]
    public string Title { get; set; }

    public bool IsAssigned { get; set; }

    [RequiredIf(nameof(IsAssigned),
        ErrorMessage = "Assignee is required if a work item is assigned")]
    public string Assignee { get; set; }
}