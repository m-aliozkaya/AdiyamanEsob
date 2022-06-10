using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Announcement;

public class Index : PageModel
{
    private readonly IAnnouncementService _announcementService;
    private const int RecordsPerPage = 6;
    public PagingDto Paging { get; set; }
    
    [TempData]
    public string ErrorMessage { get; set; }
    
    public List<Entities.Entity.Announcement> Announcement { get; set; }
    
    public Index(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }
    public async Task<IActionResult> OnGet(int currentPage)
    {
        var result = await _announcementService.GetAllByPage(RecordsPerPage, currentPage);

        Announcement = result.Data.Announcements;


        Paging = new PagingDto
        {
            TotalRecords = result.Data.TotalRecors,
            CurrentPage = currentPage,
            RecordsPerPage = RecordsPerPage
        };

        return Page();
    }
}