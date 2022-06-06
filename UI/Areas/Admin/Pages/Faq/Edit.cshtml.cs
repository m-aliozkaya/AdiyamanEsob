using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Faq;

public class Edit : PageModel
{
    private readonly IFaqService _faqService;
    
    [BindProperty]
    public Entities.Entity.Faq Faq { get; set; }

    public Edit(IFaqService faqService)
    {
        _faqService = faqService;
    }
    
    public IActionResult OnGet(int? id)
    {
        if (id.HasValue)
        {
            Faq = _faqService.GetAsync(id.Value).Result.Data;
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            Faq = new Entities.Entity.Faq();
            
            ViewData["ActionName"] = "Ekle";
        }
        
        if (Faq is null)
        {
            return Redirect("/admin/faq");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (Faq.Id > 0)
        {
            await _faqService.UpdateAsync(Faq);
        }
        else
        {
            await _faqService.AddAsync(Faq);
        }

        return Redirect("/admin/faq");
    }
}