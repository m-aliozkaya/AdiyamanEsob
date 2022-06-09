using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Images;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Announcement;

public class Edit : PageModel
{
    private readonly IAnnouncementService _announcementService;
    
    [BindProperty]
    public Entities.Entity.Announcement Announcement { get; set; }
    
    [DisplayName("Duyuru Resmi")]
    [BindProperty]
    public IFormFile UploadFile { get; set; }
    
    public Edit(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }
    public async Task<IActionResult> OnGet(int? id)
    {
        if (id.HasValue)
        {
            var result = await _announcementService.GetByIdAsync(id.Value);
            Announcement = result.Data;
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            Announcement = new Entities.Entity.Announcement();
            ViewData["ActionName"] = "Ekle";
        }
        
        if (Announcement is null)
        {
            return Redirect("/admin/announcement");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (Announcement.Id > 0)
        {
            var result = await ImageUploadHelper.UpdateResponsiveImageAsync(UploadFile, "announcement", Announcement.Image);
            Announcement.Image= result.Data;
            await _announcementService.UpdateAsync(Announcement);
        }
        else
        {
            var result=await ImageUploadHelper.UploadResponsiveImages(UploadFile, "announcement");
            Announcement.Image = result.Data;
            await _announcementService.AddAsync(Announcement);
        }

        return Redirect("/admin/announcement");
    }
}