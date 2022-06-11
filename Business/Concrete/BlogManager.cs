using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Seo;
using DataAccess.Abstract;
using Entities.Dto;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class BlogManager : IBlogService
{
    private const int HomeBlogCount = 5;
    private const int HomeLatestBlogCount = 3;

    private readonly IBlogDal _blogDal;

    public BlogManager(IBlogDal blogDal)
    {
        _blogDal = blogDal;
    }

    public async Task<IDataResult<BlogWithPageDetailDto>> GetAllByPage(int count, int? page)
    {
        var skipCount = 0;

        if (page is > 1)
        {
            skipCount = (page.Value - 1) * count;
        }

        var result = await _blogDal.GetAllByPage(skipCount, count);
        var totalRecords = await _blogDal.GetCountAsync();

        var blogPageDetailDto = new BlogWithPageDetailDto
        {
            Blogs = result,
            TotalRecors = totalRecords
        };

        return new SuccessDataResult<BlogWithPageDetailDto>(blogPageDetailDto);
    }

    public async Task<IDataResult<Blog>> GetByIdAsync(int id)
    {
        var result = await _blogDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<Blog>(result);
        }

        return new ErrorDataResult<Blog>();
    }

    public async Task<IDataResult<Blog>> GetBySeoUrlAsync(string seoUrl)
    {
        var result = await _blogDal.GetAsync(x => x.SeoUrl == seoUrl);

        if (result is not null)
        {
            return new SuccessDataResult<Blog>(result);
        }

        return new ErrorDataResult<Blog>();
    }

    public async Task<IDataResult<List<Blog>>> GetAllAsync()
    {
        var result = await _blogDal.GetAllAsync();
        return new SuccessDataResult<List<Blog>>(result);
    }

    public async Task<IDataResult<Blog>> AddAsync(Blog blog)
    {
        blog.SeoUrl = SeoHelper.GetFriendlyTitle(blog.Title);
        await _blogDal.AddAsync(blog);
        return new SuccessDataResult<Blog>(blog);
    }

    public async Task<IDataResult<Blog>> UpdateAsync(Blog blog)
    {
        if (blog is null) return new ErrorDataResult<Blog>();
        blog.SeoUrl = SeoHelper.GetFriendlyTitle(blog.Title);
        await _blogDal.UpdateAsync(blog);
        return new SuccessDataResult<Blog>(blog);
    }

    public async Task<IDataResult<Blog>> DeleteAsync(int id)
    {
        var result = await GetByIdAsync(id);

        if (!result.Success) return new ErrorDataResult<Blog>();

        await _blogDal.DeleteAsync(result.Data);
        return new SuccessDataResult<Blog>(result.Data);
    }

    public async Task<IDataResult<List<Blog>>> GetHomeBlogs()
    {
        var result = await _blogDal.GetQueryable()
            .Where(x => x.IsActive && x.IsHome)
            .OrderByDescending(x => x.CreationDate)
            .Take(HomeBlogCount).ToListAsync();

        return new SuccessDataResult<List<Blog>>(result);
    }
    
    public async Task<IDataResult<List<Blog>>> GetLatestBlogs()
    {
        var result = await _blogDal.GetQueryable()
            .Where(x => x.IsActive)
            .OrderByDescending(x => x.CreationDate)
            .Take(HomeLatestBlogCount).ToListAsync();

        return new SuccessDataResult<List<Blog>>(result);
    }
}