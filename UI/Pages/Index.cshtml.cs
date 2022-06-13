using Business.Abstract;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages;

public class IndexModel : PageModel
{
    private readonly ISettingService _settingService;
    public Setting Setting { get; set; }

    public IndexModel(ISettingService settingService)
    {
        _settingService = settingService;
    }

    public async Task<IActionResult> OnGet()
    {
        var result = await _settingService.GetByIdAsync(1);
        Setting = result.Data;
        return Page();
    }
}