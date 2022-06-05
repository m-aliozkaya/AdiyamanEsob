﻿using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface IAboutArticleService
{
    Task<IDataResult<AboutArticle>> GetAsync(int id);
    Task<IDataResult<List<AboutArticle>>> GetListAsync();
    Task<IDataResult<AboutArticle>> AddAsync(AboutArticle aboutArticle);
    Task<IDataResult<AboutArticle>> UpdateAsync(AboutArticle aboutArticle);
    Task<IDataResult<AboutArticle>> DeleteAsync(int id);
}