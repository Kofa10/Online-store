namespace OnlineStore.Domain.ValueObjects;
using OnlineStore.Domain.Exceptions;
using System.Text.RegularExpressions;



public readonly record struct Sku
{
    public string Value {get;}

    private Sku(string value) => Value = value;

    public static Sku Create(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
        {
            throw new InvalidSku("SKU cannot be empty or whitespace.");
        }
        var normalized = raw.Trim().ToUpperInvariant(); 
        if (normalized.Length < 3 || normalized.Length > 32)
        {
            throw new InvalidSku("SKU cannot be less then 3 char or more then 32");
        }
        if (!Regex.IsMatch(normalized, "^[A-Z0-9-]+$"))
        {
            throw new InvalidSku("SKU can contain only letters, numbers, or hyphens.");
        }
        

        return new Sku(normalized);
    }
}