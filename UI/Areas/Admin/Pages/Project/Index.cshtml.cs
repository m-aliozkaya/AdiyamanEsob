using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Project;

public class Index : PageModel
{
    private readonly IProjectService _projectService;

    public Index(IProjectService projectService)
    {
        _projectService = projectService;
    }
    public List<Entities.Entity.Project> Projects { get; set; }
    public async Task<IActionResult> OnGet()
    {
       var result = await _projectService.GetListAsync();
       Projects = result.Data;
       return Page();
    }
}