using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.DependencyResolvers;
using DataAccess.Context;
using Entities;
using Entities.Dto;
using Entities.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutofacBusinessModule()); });

var config = builder.Configuration;

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContextPool<EsobContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EsobDb"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeAreaFolder("Admin", "/");
    options.Conventions.AddAreaFolderApplicationModelConvention("Admin", "/", x =>
    {
        x.Filters.Add(new RequestSizeLimitAttribute(524288000));
    });
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/admin/account/login";
        options.AccessDeniedPath = "/admin/account/login";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapPost("/account/register", async (UserForRegisterDto dto, IAuthService authService) =>
{
    await authService.RegisterAsync(dto);
    return Results.Ok();
});

app.MapPost("/iletisim", async (Contact contact, IContactService contactService) =>
{
    if (contact is null)
    {
        return Results.BadRequest("Form boş gönderilemez.");
    }
    
    var result = await contactService.SendMailAsync(contact);
    contact.Date = DateTime.Now;
    await contactService.AddAsync(contact);
    
    if (result.Success)
    {
        return Results.Ok("Mesajınız başarıyla gönderildi.");
    }
    
    return Results.BadRequest(result.Message);
});

app.Run();