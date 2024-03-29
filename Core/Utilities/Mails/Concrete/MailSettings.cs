﻿namespace Core.Utilities.Mails.Concrete;

public class MailSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public bool EnableSsl { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string CompanyName { get; set; }
    public string SendTo { get; set; }
}