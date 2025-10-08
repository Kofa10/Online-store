namespace OnlineStore.Domain.ValueObjects;
using System.Net.Mail;
using OnlineStore.Domain.Exceptions;

public readonly record struct Email
{
    public string Value {get;}

    private Email(string value)=> Value = value;

    public static Email Create (string raw)
    {
        try
{
    var normalized = raw.Trim().ToLowerInvariant();
    var mail = new MailAddress(normalized);
    return new Email(mail.Address);
}
    catch
{
    throw new InvalidEmail($"Invalid email: {raw}");
}
    }
}