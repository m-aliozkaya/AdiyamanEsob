using Core.Entities.Concrete;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public class EsobContext : DbContext
{
    public EsobContext(DbContextOptions<EsobContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<AboutArticle> AboutArticles { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Circular> Circulars { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OrganizationMember> OrganizationMembers { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Legislation> Legislations { get; set; }    
    public DbSet<Setting> Settings { get; set; }
    public DbSet<PresidentInfo> PresidentInfos { get; set; }
    public DbSet<ActivityField> ActivityFields { get; set; }
    public DbSet<Service> Services { get; set; }
}