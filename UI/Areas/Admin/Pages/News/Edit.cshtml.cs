using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Images;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.News;

public class Edit : PageModel
{
    private readonly INewsService _newsService;
    
    [BindProperty]
    public Entities.Entity.News News { get; set; }
    
    [DisplayName("Haber Resmi")]
    [BindProperty]
    public IFormFile UploadFile { get; set; }
    
    public Edit(INewsService newsService)
    {
        _newsService = newsService;
    }
    public async Task<IActionResult> OnGet(int? id)
    {
        if (id.HasValue)
        {
            var result = await _newsService.GetByIdAsync(id.Value);
            News = result.Data;
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            News = new Entities.Entity.News();
            ViewData["ActionName"] = "Ekle";
        }
        
        if (News is null)
        {
            return Redirect("/admin/news");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (News.Id > 0)
        {
            var result = await ImageUploadHelper.UpdateResponsiveImageAsync(UploadFile, "news", News.Image);
            News.Image= result.Data;
            await _newsService.UpdateAsync(News);
        }
        else
        {
            var result=await ImageUploadHelper.UploadResponsiveImages(UploadFile, "news");
            News.Image = result.Data;
            await _newsService.AddAsync(News);
        }

        return Redirect("/admin/news");
    }
}