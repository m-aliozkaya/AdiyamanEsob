using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Project;

public class Edit : PageModel
{
    private readonly IProjectService _projectService;
    
    [BindProperty]
    public Entities.Entity.Project Project { get; set; }

    [DisplayName("Dosya")]
    [Required]
    [BindProperty]
    public IFormFile UploadFile { get; set; }

    public Edit(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    public IActionResult OnGet(int? id)
    {
        if (id.HasValue)
        {
            Project = _projectService.GetAsync(id.Value).Result.Data;
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            Project = new Entities.Entity.Project();
            
            ViewData["ActionName"] = "Ekle";
        }
        
        if (Project is null)
        {
            return Redirect("/admin/project");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        
        if (Project.Id > 0)
        {
            var result = await FileHelper.UpdateFileAsync(UploadFile, "project", Project.Image);
            Project.Image= result.Data;
            await _projectService.UpdateAsync(Project);
        }
        else
        {
            var result=await FileHelper.UploadFileAsync(UploadFile, "project");
            Project.Image = result.Data;
            await _projectService.AddAsync(Project);
        }

        return Redirect("/admin/project");
    }
}