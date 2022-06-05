using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Contact;

public class Detail : PageModel
{
    private IContactService _contactService;

    public Detail(IContactService contactService)
    {
        _contactService = contactService;
    }

    public Entities.Entity.Contact Contact { get; set; }
    public async Task<IActionResult> OnGet(int id)
    {
       Contact=(await _contactService.GetByIdAsync(id)).Data;
        if (Contact==null)
        {
            return RedirectToPage("Index");
        }
        return Page();
       return Page();
    }
}