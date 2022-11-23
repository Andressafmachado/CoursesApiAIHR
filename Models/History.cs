using System.Text.Json.Serialization;

namespace CourseStore.Models 
{
public class History
    {
          public int Id { get; set; }
          public DateTime? Created {get; set;}
          public string? SelectedCourses { get; set; }
          public DateTime? StartDate { get; set; }
          public DateTime? EndDate { get; set; }
          public int? TotalHours { get; set; }
          public int? HoursPerWeek { get; set; }
          
    }
}
