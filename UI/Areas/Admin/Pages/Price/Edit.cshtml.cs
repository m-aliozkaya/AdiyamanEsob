using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Price;

public class Edit : PageModel
{
    private readonly IPriceService _priceService;
    
    [BindProperty]
    public Entities.Entity.Price Price { get; set; }
    [BindProperty]
    public string DecisionDate { get; set; }
    
    public Edit(IPriceService priceService)
    {
        _priceService = priceService;
    }
    
    public IActionResult OnGet(int? id)
    {
        if (id.HasValue)
        {
            Price = _priceService.GetAsync(id.Value).Result.Data;
            DecisionDate = Price.DecisionDate.ToShortDateString();
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            Price =new Entities.Entity.Price()
            {
                IsCentre = false
            };
            DecisionDate = DateTime.Now.ToShortDateString();
            ViewData["ActionName"] = "Ekle";
        }
        
        if (Price is null)
        {
            return Redirect("/admin/price");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        Price.DecisionDate = DateTime.Parse(DecisionDate);
        if (Price.Id > 0)
        {
            await _priceService.UpdateAsync(Price);
        }
        else
        {
            await _priceService.AddAsync(Price);
        }

        return Redirect("/admin/price");
    }
}