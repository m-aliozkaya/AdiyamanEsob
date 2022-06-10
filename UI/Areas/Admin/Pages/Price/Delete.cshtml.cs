using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Price;

public class Delete : PageModel
{
    private readonly IPriceService _priceService;

    public Delete(IPriceService priceService)
    {
        _priceService = priceService;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        var price = await _priceService.GetAsync(id);
        await _priceService.DeleteAsync(id);
        return Redirect("/admin/price");
    }
}