using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Announcement;

public class AnnouncementSingle : PageModel
{
    private readonly IAnnouncementService _announcementService;
    public Entities.Entity.Announcement Announcement { get; set; }

    public AnnouncementSingle(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }
    
    public async Task<IActionResult> OnGet(string seoUrl)
    {
        var result = await _announcementService.GetBySeoUrlAsync(seoUrl);

        if (!result.Success)
        {
           return Redirect("/NotFound");
        }

        Announcement = result.Data;
        return Page();
    }
}