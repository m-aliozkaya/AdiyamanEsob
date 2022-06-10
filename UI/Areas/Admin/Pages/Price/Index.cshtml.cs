using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Price;

public class Index : PageModel
{
    private readonly IPriceService _priceService;

    public Index(IPriceService priceService)
    {
        _priceService = priceService;
    }

    public List<Entities.Entity.Price> Prices { get; set; }

    public async Task<IActionResult> OnGet(bool? isCentre)
    {
        if (isCentre.HasValue)
        {
            if (isCentre.Value)
            {
                ViewData["PriceType"] = "Merkez";
            }
            else
            {
                ViewData["PriceType"] = "Şube";
            }
        }

        var result = await _priceService.GetListAsync(isCentre);
        Prices = result.Data;
        return Page();
    }
}