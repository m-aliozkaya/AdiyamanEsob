using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Entity;

namespace Business.Concrete;

public class FaqManager : IFaqService
{
    private readonly IFaqDal _faqDal;

    public FaqManager(IFaqDal faqDal)
    {
        _faqDal = faqDal;
    }
    
    public async Task<IDataResult<Faq>> GetAsync(int id)
    {
        var result = await _faqDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<Faq>(result); 
        }

        return new ErrorDataResult<Faq>();
    }

    public async Task<IDataResult<List<Faq>>> GetListAsync()
    {
        var result = await _faqDal.GetAllAsync();
        return new SuccessDataResult<List<Faq>>(result);
    }

    public async Task<IDataResult<Faq>> AddAsync(Faq faq)
    {
        await _faqDal.AddAsync(faq);
        return new SuccessDataResult<Faq>(faq);
    }

    public async Task<IDataResult<Faq>> UpdateAsync(Faq faq)
    {
        if (faq is null) return new ErrorDataResult<Faq>();
        
        await _faqDal.UpdateAsync(faq);
        return new SuccessDataResult<Faq>(faq);
    }

    public async Task<IDataResult<Faq>> DeleteAsync(int id)
    {
        var result = await GetAsync(id);
        
        if (!result.Success) return new ErrorDataResult<Faq>();
        
        await _faqDal.DeleteAsync(result.Data);
        return new SuccessDataResult<Faq>(result.Data);
    }
}