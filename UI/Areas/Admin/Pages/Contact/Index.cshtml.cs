using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Contact
{
    public class Index : PageModel
    {
        
        private readonly IContactService _contactService;

        public Index(IContactService contactService)
        {
            _contactService = contactService;
        }
        public List<Entities.Entity.Contact> Contacts { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var result = await _contactService.GetAllAsync();
            Contacts = result.Data;
            return Page();
        }
    }
}
