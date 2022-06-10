using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Images;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Blog;

public class Edit : PageModel
{
    private readonly IBlogService _blogService;
    
    [BindProperty]
    public Entities.Entity.Blog Blog { get; set; }
    
    [DisplayName("Blog Resmi")]
    [BindProperty]
    public IFormFile UploadFile { get; set; }
    
    public Edit(IBlogService blogService)
    {
        _blogService = blogService;
    }
    public async Task<IActionResult> OnGet(int? id)
    {
        if (id.HasValue)
        {
            var result = await _blogService.GetByIdAsync(id.Value);
            Blog = result.Data;
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            Blog = new Entities.Entity.Blog();
            ViewData["ActionName"] = "Ekle";
        }
        
        if (Blog is null)
        {
            return Redirect("/admin/blog");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (Blog.Id > 0)
        {
            var result = await ImageUploadHelper.UpdateResponsiveImageAsync(UploadFile, "blog", Blog.Image);

            if (result.Success)
            {
                Blog.Image= result.Data;
            }
            
            await _blogService.UpdateAsync(Blog);
        }
        else
        {
            var result=await ImageUploadHelper.UploadResponsiveImages(UploadFile, "blog");
            Blog.Image = result.Data;
            await _blogService.AddAsync(Blog);
        }

        return Redirect("/admin/blog");
    }
}