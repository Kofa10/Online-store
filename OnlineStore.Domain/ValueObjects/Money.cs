namespace OnlineStore.Domain.ValueObjects;
using OnlineStore.Domain.Exceptions;
public readonly record struct Money (decimal Amount)
{
    public static Money Create(decimal amount)
    {
        if (amount < 0)
        {
            throw new InvalidMoneyAmount("Amount must be >= 0");
            
        }
        return new Money(amount);
    }
    public static Money operator +(Money a,Money b) => new(a.Amount+b.Amount);
    public static Money operator *(Money a, Money b) => new(a.Amount*b.Amount);
    public static Money operator *(Money money, int multiplier) => new Money(money.Amount * multiplier);

    public override string ToString() => Amount.ToString("F2");
}