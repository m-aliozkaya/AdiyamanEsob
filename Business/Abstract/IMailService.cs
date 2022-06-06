using Core.Utilities.Mails.Abstract;
using Core.Utilities.Result.Abstract;

namespace Business.Abstract;

public interface IMailService
{
    Task<IResult> SendAsync(IMail mail);
}