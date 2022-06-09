using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Announcement;

public class ChangeStatus : PageModel
{
    private readonly IAnnouncementService _announcementService;

    public ChangeStatus(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }
    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var result = await _announcementService.GetByIdAsync(id);
        result.Data.IsActive = !result.Data.IsActive;
        await _announcementService.UpdateAsync(result.Data);

        return Redirect("/admin/announcement");
    }
}