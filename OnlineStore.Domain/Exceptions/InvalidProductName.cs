namespace OnlineStore.Domain.Exceptions;


public sealed class InvalidProductName : DomainException
{
    public InvalidProductName(string message) : base(message) { }
}