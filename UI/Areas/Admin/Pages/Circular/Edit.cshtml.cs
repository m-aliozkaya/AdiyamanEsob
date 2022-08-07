using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Circular;

public class Edit : PageModel
{
    private readonly ICircularService _circularService;
    
    [BindProperty]
    public Entities.Entity.Circular Circular { get; set; }

    [DisplayName("Dosya")]
    [BindProperty]
    public IFormFile UploadFile { get; set; }

    public Edit(ICircularService circularService)
    {
        _circularService = circularService;
    }
    
    public IActionResult OnGet(int? id)
    {
        if (id.HasValue)
        {
            Circular = _circularService.GetAsync(id.Value).Result.Data;
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            Circular = new Entities.Entity.Circular
            {
                Year = DateTime.Now.Year
            };
            
            ViewData["ActionName"] = "Ekle";
        }
        
        if (Circular is null)
        {
            return Redirect("/admin/circular");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (Circular.Id > 0)
        {
            
            if (UploadFile != null)
            {
                var result = await FileHelper.UpdateFileAsync(UploadFile, "circular", Circular.File);
                Circular.File= result.Data;
            }

            await _circularService.UpdateAsync(Circular);
        }
        else
        {
            var result=await FileHelper.UploadFileAsync(UploadFile, "circular");
            Circular.File = result.Data;
            await _circularService.AddAsync(Circular);
        }

        return Redirect("/admin/circular");
    }
}