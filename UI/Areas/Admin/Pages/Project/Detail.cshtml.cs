using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Project;

public class Detail : PageModel
{
    private readonly IProjectService _projectService;

    public Entities.Entity.Project Project { get; set; }
    
    public Detail(IProjectService projectService)
    {
        _projectService = projectService;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        var result = await _projectService.GetAsync(id);

        if (result.Data == null)
        {
            return Redirect("/admin/project");
        }

        Project = result.Data;

        return Page();
    }
}