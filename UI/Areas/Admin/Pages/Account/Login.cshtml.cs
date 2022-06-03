using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Account;

[AllowAnonymous]
public class Login : PageModel
{
    private readonly IAuthService _authService;

    [Required]
    [BindProperty]
    public string Username { get; set; }

    [Required]
    [BindProperty]
    public string Password { get; set; }

    public Login(IAuthService authService)
    {
        _authService = authService;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(UserForLoginDto userForLoginDto, string ReturnUrl)
    {
        var result = await _authService.LoginAsync(userForLoginDto);

        if (!result.Success)
        {
            ViewData["ErrorMessage"] = "Kullanıcı adı veya şifre yanlış";
            return Page();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userForLoginDto.Username)
        };

        var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        ClaimsPrincipal principal = new(userIdentity);
        await HttpContext.SignInAsync(principal);

        if (!string.IsNullOrEmpty(ReturnUrl))
        {
            return Redirect(ReturnUrl);
        }
        else
        {
            return Redirect("/admin/");
        }
    }
}