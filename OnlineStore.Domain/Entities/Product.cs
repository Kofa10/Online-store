namespace OnlineStore.Domain.Entities;

using OnlineStore.Domain.ValueObjects;
using OnlineStore.Domain.Exceptions;

public sealed class Product
{
    public Sku Sku { get; }
    public string Name { get; private set; }
    public Money Price { get; private set; }
    public int StockQuantity { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; }

    private Product(Sku sku, string name, Money price, int stock, bool isActive)
    {
        // TODO: присвоения полей + CreatedAt = DateTime.UtcNow;
        Sku = sku;
        Name = name;
        Price = price;
        StockQuantity = stock;
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
    }

    public static Product Create(Sku sku, string name, Money price, int initialStock = 0, bool isActive = true)
    {
        // TODO: name не пустой → иначе InvalidProductName
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidProductName("Product name cannot be empty or whitespace");
        }
            // TODO: initialStock >= 0 → иначе InvalidStockAmount
        if (initialStock < 0){
            throw new InvalidStockAmount("Stock amount not valid");
        }
        var cleaned = name.Trim();
        if (cleaned.Length>100){
            throw new InvalidProductName("cannot exceed 100 characters");
        }
        // Возврат: new Product(sku, name, price, initialStock, isActive);
        return new Product(sku,cleaned,price,initialStock,isActive);
    }

    public void ChangeName(string newName)
    {
        //проверка not null/whitespace → иначе InvalidProductName
        if (string.IsNullOrWhiteSpace(newName)){
            throw new InvalidProductName("Product name cannot be empty or whitespace");
        }
        //lenght check
        var cleaned = newName.Trim();
        if (cleaned.Length >100){
            throw  new InvalidProductName("Product name cannot exceed 100 characters.");
        }

        Name = cleaned;

    }

    public void UpdatePrice(Money newPrice)
    {
        // TODO: newPrice.Amount >= 0 (Money это уже гарантит) → Price = newPrice;
        
        if (newPrice.Amount < 0){
            throw new InvalidMoneyAmount("Money amount cannot be negative.");
        }
        Price = newPrice;
    }

    public void IncreaseStock(int qty)
    {
        // TODO: qty > 0 → иначе InvalidStockAmount; затем StockQuantity += qty;
        if (qty <= 0){
            throw new InvalidStockAmount("Quantity must be greater than 0.");
        }
        StockQuantity+=qty;
    }

    public void DecreaseStock(int qty)
    {
        // TODO: qty > 0 и StockQuantity - qty >= 0 → иначе InsufficientStock; затем StockQuantity -= qty;
        if (qty<=0)
        {
            throw new InvalidStockAmount("Quantity must be greater than 0.");
        }
        if (StockQuantity < qty)
        {
            throw new InsufficientStock("Not enough items in stock.");
        }
        StockQuantity -= qty;
    }
public void Activate()   { IsActive = true; }
public void Deactivate() { IsActive = false; }


    
}
