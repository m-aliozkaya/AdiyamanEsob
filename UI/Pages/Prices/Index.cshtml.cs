using Business.Abstract;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Prices;

public class Index : PageModel
{
    private readonly IPriceService _priceService;
    public List<Price> CentralPrices { get; set; }
    public List<Price> BranchPrices { get; set; }

    public Index(IPriceService priceService)
    {
        _priceService = priceService;
    }
    public async Task<IActionResult> OnGetAsync()
    {
        var central = await _priceService.GetListAsync(true);
        CentralPrices = central.Data;

        var branch = await _priceService.GetListAsync(false);
        BranchPrices = branch.Data;

        return Page();
    }
}