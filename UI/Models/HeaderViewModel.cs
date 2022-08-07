using Entities.Entity;

namespace UI.Models;

public class HeaderViewModel
{
    public List<int> CircularYears { get; set; }
    public Setting Setting { get; set; }
    public List<Service> Services { get; set; }
    public List<ActivityField> ActivityFields { get; set; }
}