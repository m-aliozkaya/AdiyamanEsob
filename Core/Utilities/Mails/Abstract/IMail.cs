namespace Core.Utilities.Mails.Abstract;

public interface IMail
{
    string Subject { get; }
    string Title { get; }
    Dictionary<string, string> MailContent { get; }
}