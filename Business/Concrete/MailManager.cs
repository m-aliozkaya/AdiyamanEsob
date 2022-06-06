using Business.Abstract;
using Core.Utilities.Mails.Abstract;
using Core.Utilities.Mails.Concrete;
using Core.Utilities.Result.Abstract;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete;

public class MailManager : IMailService
{
    private readonly IConfiguration _configuration;

    public MailManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IResult> SendAsync(IMail mail)
    {
        var mailHelper = new MailHelper(_configuration);
        return await mailHelper.SendAsync(mail);
    }
}