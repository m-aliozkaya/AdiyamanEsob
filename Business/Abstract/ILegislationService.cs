using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface ILegislationService
{
    Task<IDataResult<Legislation>> GetAsync(int id);
    Task<IDataResult<List<Legislation>>> GetListAsync();
    Task<IDataResult<Legislation>> AddAsync(Legislation aboutArticle);
    Task<IDataResult<Legislation>> UpdateAsync(Legislation aboutArticle);
    Task<IDataResult<Legislation>> DeleteAsync(int id);
}