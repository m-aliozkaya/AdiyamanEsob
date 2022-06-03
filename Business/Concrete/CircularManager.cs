using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Entity;

namespace Business.Concrete;

public class CircularManager : ICircularService
{
    private readonly ICircularDal _circularDal;

    public CircularManager(ICircularDal circularDal)
    {
        _circularDal = circularDal;
    }
    
    public async Task<IDataResult<Circular>> GetAsync(int id)
    {
        var result = await _circularDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<Circular>(result); 
        }

        return new ErrorDataResult<Circular>();
    }

    public async Task<IDataResult<List<Circular>>> GetListAsync()
    {
        var result = await _circularDal.GetAllAsync();
        return new SuccessDataResult<List<Circular>>(result);
    }

    public async Task<IDataResult<Circular>> AddAsync(Circular circular)
    {
        await _circularDal.AddAsync(circular);
        return new SuccessDataResult<Circular>(circular);
    }

    public async Task<IDataResult<Circular>> UpdateAsync(Circular circular)
    {
        if (circular is null) return new ErrorDataResult<Circular>();
        
        await _circularDal.UpdateAsync(circular);
        return new SuccessDataResult<Circular>(circular);
    }

    public async Task<IDataResult<Circular>> DeleteAsync(int id)
    {
        var result = await GetAsync(id);
        
        if (!result.Success) return new ErrorDataResult<Circular>();
        
        await _circularDal.DeleteAsync(result.Data);
        return new SuccessDataResult<Circular>(result.Data);
    }
}