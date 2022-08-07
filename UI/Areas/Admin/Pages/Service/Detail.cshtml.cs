using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Service;

public class Detail : PageModel
{
    private readonly IServiceService _serviceService;
    public Entities.Entity.Service Service { get; set; }

    public Detail(IServiceService announcementService)
    {
        _serviceService = announcementService;
    }
    public async Task<IActionResult> OnGet(string seoUrl)
    {
        var result = await _serviceService.GetBySeoUrlAsync(seoUrl);

        if (result.Data == null)
        {
            TempData["ErrorMessage"] = "Hizmet detayı bulunamadı.";
            return Redirect("/admin/service");
        }

        Service = result.Data;

        return Page();
    }
}