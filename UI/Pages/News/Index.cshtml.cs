using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.News;

public class Index : PageModel
{
    private readonly INewsService _newsService;
    private const int RecordsPerPage = 8;
    public PagingDto Paging { get; set; }
    public List<Entities.Entity.News> News { get; set; }

    public Index(INewsService newsService)
    {
        _newsService = newsService;
    }
    
    public async Task<IActionResult> OnGet(int currentPage)
    {
        var result = await _newsService.GetAllByPage(RecordsPerPage, currentPage);
        News = result.Data.News;

        Paging = new PagingDto
        {
            TotalRecords = result.Data.TotalRecors,
            CurrentPage = currentPage,
            RecordsPerPage = RecordsPerPage
        };

        return Page();
    }
}