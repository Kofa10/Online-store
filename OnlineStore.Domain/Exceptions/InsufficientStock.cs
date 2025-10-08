namespace OnlineStore.Domain.Exceptions;


public sealed class InsufficientStock : DomainException
{
    public InsufficientStock(string message) : base(message) { }
}