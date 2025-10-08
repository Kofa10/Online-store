namespace OnlineStore.Domain.Exceptions;


public sealed class InvalidMoneyAmount : DomainException
{
    public InvalidMoneyAmount(string message) : base(message) { }
}