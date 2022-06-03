using Core.Utilities.Mails.Abstract;

namespace Core.Utilities.Mails.Concrete;

public class Mail : IMail
{
    public string Subject { get; }
    public string Title { get; }
    public Dictionary<string, string> MailContent { get; }

    public Mail(string subject, Dictionary<string, string> mailContent, string title)
    {
        Subject = subject;
        MailContent = mailContent;
        Title = title;
    }
}