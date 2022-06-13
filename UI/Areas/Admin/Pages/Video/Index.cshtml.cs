using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Video;

public class Index : PageModel
{
    private readonly IVideoService _videoService;

    public Index(IVideoService videoService)
    {
        _videoService = videoService;
    }
    public List<Entities.Entity.Video> Videos { get; set; }
    public async Task<IActionResult> OnGet()
    {
       var result = await _videoService.GetListAsync(null);
       Videos = result.Data;
       return Page();
    }
}