using Business.Abstract;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Circulars
{
    public class IndexYearModel : PageModel
    {
        private readonly ICircularService _circularService;

        public List<Circular> Circulars { get; set; }
        public int Year { get; set; }

        public IndexYearModel(ICircularService circularService)
        {
            _circularService = circularService;
        }

        public async Task<IActionResult> OnGet(int year)
        {
            var result = await _circularService.GetListAsync(year);

            if (result.Data.Count <= 0)
            {
                return RedirectToPage("./NotFound");
            }

            Circulars = result.Data;
            Year = Circulars[0].Year;

            return Page();
        }
    }
}
