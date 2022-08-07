using Business.Abstract;
using Core.Utilities.Mails.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Entity;

namespace Business.Concrete;

public class PresidentManager : IPresidentService
{
    private readonly IPresidentDal _presidentDal;

    public PresidentManager(IPresidentDal presidentDal)
    {
        _presidentDal = presidentDal;
    }

    public async Task<IResult> AddAsync(PresidentInfo president)
    {
        await _presidentDal.AddAsync(president);
        return new SuccessResult();
    }
    
    public async Task<IDataResult<PresidentInfo>> GetByIdAsync(int id)
    {
        var president = await _presidentDal.GetAsync(x => x.Id == id);
        return new SuccessDataResult<PresidentInfo>(president);
    }


    public async Task<IResult> UpdateAsync(PresidentInfo president)
    {
        await _presidentDal.UpdateAsync(president);
        return new SuccessResult();
    }
}