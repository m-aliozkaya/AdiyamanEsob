using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Announcement;

public class Detail : PageModel
{
    private readonly IAnnouncementService _announcementService;
    public Entities.Entity.Announcement Announcement { get; set; }

    public Detail(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }
    public async Task<IActionResult> OnGet(string seoUrl)
    {
        var result = await _announcementService.GetBySeoUrlAsync(seoUrl);

        if (result.Data == null)
        {
            TempData["ErrorMessage"] = "Duyuru detayı bulunamadı.";
            return Redirect("/admin/announcement");
        }

        Announcement = result.Data;

        return Page();
    }
}