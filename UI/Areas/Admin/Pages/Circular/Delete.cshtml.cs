using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Circular;

public class Delete : PageModel
{
    private readonly ICircularService _circularService;

    public Delete(ICircularService circularService)
    {
        _circularService = circularService;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        var circular = await _circularService.GetAsync(id);
        FileHelper.DeleteFile("circular", circular.Data.File);
        await _circularService.DeleteAsync(id);
        return Redirect("/admin/circular");
    }
}