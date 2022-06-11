using Entities.Entity;

namespace Entities.Dto;

public class BlogWithPageDetailDto
{
    public int TotalRecors { get; set; }
    public List<Blog> Blogs { get; set; }
}