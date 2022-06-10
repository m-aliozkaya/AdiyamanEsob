using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Video;

public class Edit : PageModel
{
    private readonly IVideoService _videoService;
    
    [BindProperty]
    public Entities.Entity.Video Video { get; set; }

    [DisplayName("Video Resmi")]
    [Required]
    [BindProperty]
    public IFormFile UploadFile { get; set; }

    public Edit(IVideoService videoService)
    {
        _videoService = videoService;
    }
    
    public IActionResult OnGet(int? id)
    {
        if (id.HasValue)
        {
            Video = _videoService.GetAsync(id.Value).Result.Data;
            
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            Video = new Entities.Entity.Video();
            
            ViewData["ActionName"] = "Ekle";
        }
        
        if (Video is null)
        {
            return Redirect("/admin/video");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        
        if (Video.Id > 0)
        {
            var result = await FileHelper.UpdateFileAsync(UploadFile, "video", Video.Image);
            Video.Image= result.Data;
            await _videoService.UpdateAsync(Video);
        }
        else
        {
            var result=await FileHelper.UploadFileAsync(UploadFile, "video");
            Video.Image = result.Data;
            await _videoService.AddAsync(Video);
        }

        return Redirect("/admin/video");
    }
}