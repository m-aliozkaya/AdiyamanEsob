using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Dto;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IMapper _mapper;
    public string Result { get; set; }
    public BookDto Book { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IActionResult> OnGet()
    {
        return Page();
    }
}