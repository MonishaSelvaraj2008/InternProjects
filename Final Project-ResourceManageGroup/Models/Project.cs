namespace ResourceManageGroup.Models;
using System.ComponentModel.DataAnnotations;

public class Project{
    public int ProjectId { get; set; }
    [RegularExpression(@"^[0-9a-zA-Z\s]+$", ErrorMessage = "Project name must contain only letters and spaces and numbers.")]
    public string? ProjectName { get; set; }
    public string? ProjectDescription { get; set; }
    public string? ProjectStartTime{ get; set;}
    [ProjectDate(ErrorMessage = "Invalid Project dates.")]
    public string? ProjectEndTime{ get; set;}
    public string? ProjectLead{ get; set;}
    public string? ProjectType { get; set; }
}