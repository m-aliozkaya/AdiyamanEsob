using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Project;

public class Delete : PageModel
{
    private readonly IProjectService _projectService;

    public Delete(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        var project = await _projectService.GetAsync(id);
        FileHelper.DeleteFile("project", project.Data.Image);
        await _projectService.DeleteAsync(id);
        return Redirect("/admin/project");
    }
}