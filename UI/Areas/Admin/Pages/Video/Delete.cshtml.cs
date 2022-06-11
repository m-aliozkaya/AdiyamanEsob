using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Video;

public class Delete : PageModel
{
    private readonly IVideoService _videoService;

    public Delete(IVideoService videoService)
    {
        _videoService = videoService;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        var video = await _videoService.GetAsync(id);
        FileHelper.DeleteFile("video", video.Data.Image);
        await _videoService.DeleteAsync(id);
        return Redirect("/admin/video");
    }
}