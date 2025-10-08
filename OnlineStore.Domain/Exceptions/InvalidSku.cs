namespace OnlineStore.Domain.Exceptions;

public sealed class InvalidSku : DomainException
{
    public InvalidSku(string message) : base(message) { }
}