using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Seo;
using DataAccess.Abstract;
using Entities.Entity;

namespace Business.Concrete;

public class ServiceManager : IServiceService
{
    private readonly IServiceDal _serviceDal;

    public ServiceManager(IServiceDal serviceDal)
    {
        _serviceDal = serviceDal;
    }
    
    public async Task<IDataResult<Service>> GetAsync(int id)
    {
        var result = await _serviceDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<Service>(result); 
        }

        return new ErrorDataResult<Service>();
    }
    
    public async Task<IDataResult<Service>> GetBySeoUrlAsync(string seoUrl)
    {
        var result = await _serviceDal.GetAsync(x => x.SeoUrl == seoUrl);

        if (result is not null)
        {
            return new SuccessDataResult<Service>(result);
        }

        return new ErrorDataResult<Service>();
    }

    public async Task<IDataResult<List<Service>>> GetListAsync()
    {
        var result = await _serviceDal.GetAllAsync();
        return new SuccessDataResult<List<Service>>(result);
    }

    public async Task<IDataResult<List<Service>>> GetHome()
    {
        var result = await _serviceDal.GetAllAsync(x => x.IsActive);
        return new SuccessDataResult<List<Service>>(result);
    }

    public async Task<IDataResult<Service>> AddAsync(Service service)
    {
        service.SeoUrl = SeoHelper.GetFriendlyTitle(service.Title);
        await _serviceDal.AddAsync(service);
        return new SuccessDataResult<Service>(service);
    }

    public async Task<IDataResult<Service>> UpdateAsync(Service service)
    {
        if (service is null) return new ErrorDataResult<Service>();
        service.SeoUrl = SeoHelper.GetFriendlyTitle(service.Title);
        await _serviceDal.UpdateAsync(service);
        return new SuccessDataResult<Service>(service);
    }

    public async Task<IDataResult<Service>> DeleteAsync(int id)
    {
        var result = await GetAsync(id);
        
        if (!result.Success) return new ErrorDataResult<Service>();
        
        await _serviceDal.DeleteAsync(result.Data);
        return new SuccessDataResult<Service>(result.Data);
    }
}