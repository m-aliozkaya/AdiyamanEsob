using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Images;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.ActivityField;

public class Edit : PageModel
{
    private readonly IActivityFieldService _activityFieldService;
    
    [BindProperty]
    public Entities.Entity.ActivityField ActivityField { get; set; }

    public Edit(IActivityFieldService activityFieldService)
    {
        _activityFieldService = activityFieldService;
    }
    public async Task<IActionResult> OnGet(int? id)
    {
        if (id.HasValue)
        {
            var result = await _activityFieldService.GetAsync(id.Value);
            ActivityField = result.Data;
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            ActivityField = new Entities.Entity.ActivityField();
            ViewData["ActionName"] = "Ekle";
        }
        
        if (ActivityField is null)
        {
            return Redirect("/admin/activityField");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (ActivityField.Id > 0)
        {
            await _activityFieldService.UpdateAsync(ActivityField);
        }
        else
        {
            await _activityFieldService.AddAsync(ActivityField);
        }

        return Redirect("/admin/activityField");
    }
}