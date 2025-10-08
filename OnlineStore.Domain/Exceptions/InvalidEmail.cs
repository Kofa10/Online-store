namespace OnlineStore.Domain.Exceptions;


public sealed class InvalidEmail : DomainException
{
    public InvalidEmail(string message) : base(message) { }
}