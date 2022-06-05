using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Room;

public class Index : PageModel
{
    private readonly IRoomService _roomService;

    public Index(IRoomService roomService)
    {
        _roomService = roomService;
    }
    public List<Entities.Entity.Room> Rooms { get; set; }
    public async Task<IActionResult> OnGet()
    {
       var result = await _roomService.GetListAsync();
       Rooms = result.Data;
       return Page();
    }
}