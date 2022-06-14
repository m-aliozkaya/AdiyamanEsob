using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class PriceManager : IPriceService
{
    private readonly IPriceDal _priceDal;

    public PriceManager(IPriceDal priceDal)
    {
        _priceDal = priceDal;
    }

    public async Task<IDataResult<Price>> GetAsync(int id)
    {
        var result = await _priceDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<Price>(result);
        }

        return new ErrorDataResult<Price>();
    }
    
    public async Task<IDataResult<List<Price>>> GetListAsync()
    {
        var result = await _priceDal.GetQueryable().OrderByDescending(x => x.DecisionDate).ToListAsync();
        
        return new SuccessDataResult<List<Price>>(result);
    }

    public async Task<IDataResult<List<Price>>> GetListAsync(bool? isCentre)
    {
        List<Price> result;
        if (!isCentre.HasValue)
        {
            result = await _priceDal.GetAllAsync();
        }
        else
        {
            result  = await _priceDal.GetAllAsync(x => x.IsCentre == isCentre);
        }

        return new SuccessDataResult<List<Price>>(result);
    }

    public async Task<IDataResult<Price>> AddAsync(Price price)
    {
        await _priceDal.AddAsync(price);
        return new SuccessDataResult<Price>(price);
    }

    public async Task<IDataResult<Price>> UpdateAsync(Price price)
    {
        if (price is null) return new ErrorDataResult<Price>();

        await _priceDal.UpdateAsync(price);
        return new SuccessDataResult<Price>(price);
    }

    public async Task<IDataResult<Price>> DeleteAsync(int id)
    {
        var result = await GetAsync(id);

        if (!result.Success) return new ErrorDataResult<Price>();

        await _priceDal.DeleteAsync(result.Data);
        return new SuccessDataResult<Price>(result.Data);
    }
}