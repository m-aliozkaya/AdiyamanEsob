using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Price;

public class Detail : PageModel
{
    private readonly IPriceService _priceService;
    public Entities.Entity.Price Price { get; set; }
    
    public Detail(IPriceService priceService)
    {
        _priceService = priceService;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        var result = await _priceService.GetAsync(id);

        if (result.Data is null)
        {
            return Redirect("/admin/price");
        }

        Price = result.Data;

        return Page();
    }
}