using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface IFaqService
{
    Task<IDataResult<Faq>> GetAsync(int id);
    Task<IDataResult<List<Faq>>> GetListAsync();
    Task<IDataResult<List<Faq>>> GetActiveFaq();
    Task<IDataResult<Faq>> AddAsync(Faq faq);
    Task<IDataResult<Faq>> UpdateAsync(Faq faq);
    Task<IDataResult<Faq>> DeleteAsync(int id);
    Task<IDataResult<Faq>> GetBySeoUrl(string seoUrl);
}