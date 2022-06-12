using Business.Abstract;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Rooms;

public class Index : PageModel
{
    private readonly IRoomService _roomService;
    public List<Room> CentralRooms { get; set; }
    public List<Room> BranchRooms { get; set; }

    public Index(IRoomService roomService)
    {
        _roomService = roomService;
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        var central = await _roomService.GetListAsync(true);
        CentralRooms = central.Data;

        var branch = await _roomService.GetListAsync(false);
        BranchRooms = branch.Data;

        return Page();
    }
}