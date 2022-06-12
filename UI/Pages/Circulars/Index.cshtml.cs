using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Circulars
{
    public class IndexModel : PageModel
    {
        private readonly ICircularService _circularService;

        public IndexModel(ICircularService circularService)
        {
            _circularService = circularService;
        }

        public List<int> Years { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var result = await _circularService.GetYearsAsync();
            Years = result.Data;

            return Page();
        }
    }
}
