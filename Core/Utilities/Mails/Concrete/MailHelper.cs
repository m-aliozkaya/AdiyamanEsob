using System.Net;
using System.Net.Mail;
using Core.Utilities.Mails.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.Mails.Concrete;

public class MailHelper
{
    private readonly IConfiguration _configuration;
    private readonly MailSettings _mailSettings;

    public MailHelper(IConfiguration configuration)
    {
        _configuration = configuration;
        _mailSettings = _configuration.GetSection("MailSettings").Get<MailSettings>();
    }

    public async Task<IResult> SendAsync(IMail mail)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(_mailSettings.Email, _mailSettings.CompanyName);
        mailMessage.Subject = mail.Subject;
        mailMessage.Body = CreateMailBody(mail.MailContent, mail.Title);
        mailMessage.IsBodyHtml = true;
        mailMessage.To.Add(_mailSettings.SendTo);

        SmtpClient smtp = new SmtpClient();
        smtp.Credentials = new NetworkCredential(_mailSettings.Email, _mailSettings.Password);
        smtp.Host = _mailSettings.Host;
        smtp.Port = _mailSettings.Port;
        smtp.EnableSsl = _mailSettings.EnableSsl;

        try
        {
            await smtp.SendMailAsync(mailMessage);
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }

        return new SuccessResult();
    }

    private string CreateMailBody(Dictionary<string, string> data, string title)
    {
        var htmlStart = @"<table style=""margin: 50px"">
            <h1 style = ""margin-bottom: 20px"">" + title + @"</h1> <hr/>";
        var htmlEnd = @"</table>";

        var content = "";

        foreach (var item in data)
        {
            content += @"
                        <tr>
                            <td>
                                <h3>" + item.Key + @"</h3>
                                <p style=""color: #777777"">" + item.Value + @"</p>
                            </td >
                        </tr >
                        <br/>
                ";
        }

        return htmlStart + content + htmlEnd;
    }
}