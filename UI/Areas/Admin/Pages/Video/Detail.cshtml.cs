using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Video;

public class Detail : PageModel
{
    private readonly IVideoService _videoService;

    public Entities.Entity.Video Video { get; set; }
    
    public Detail(IVideoService videoService)
    {
        _videoService = videoService;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        var result = await _videoService.GetAsync(id);

        if (result.Data == null)
        {
            return Redirect("/admin/video");
        }

        Video = result.Data;

        return Page();
    }
}