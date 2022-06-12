using Business.Abstract;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Projects;

public class Index : PageModel
{
    private readonly IProjectService _projectService;
    public List<Project> Project { get; set; }

    public Index(IProjectService projectService)
    {
        _projectService = projectService;
    }
    public async Task<IActionResult> OnGet()
    {
        var projects = await _projectService.GetListAsync();
        Project = projects.Data;

        return Page();
    }
}