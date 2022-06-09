using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Announcement;

public class Delete : PageModel
{
    private readonly IAnnouncementService _announcementService;

    public Delete(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }
    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var announcement = await _announcementService.GetByIdAsync(id);
        FileHelper.DeleteFile("announcement/small", announcement.Data.Image);
        FileHelper.DeleteFile("announcement/medium", announcement.Data.Image);

        await _announcementService.DeleteAsync(id);

        return Redirect("/admin/announcement");
    }
}