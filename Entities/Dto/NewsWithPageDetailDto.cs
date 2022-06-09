using Entities.Entity;

namespace Entities.Dto;

public class NewsWithPageDetailDto
{
    public int TotalRecors { get; set; }
    public List<News> News { get; set; }
}