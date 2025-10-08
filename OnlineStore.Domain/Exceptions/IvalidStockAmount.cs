namespace OnlineStore.Domain.Exceptions;


public sealed class InvalidStockAmount : DomainException
{
    public InvalidStockAmount(string message) : base(message) { }
}