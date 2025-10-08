namespace OnlineStore.Domain.Entities;
using OnlineStore.Domain.ValueObjects;
using OnlineStore.Domain.Exceptions;

// TODO: добавить проверки инвариантов (Quantity > 0, UnitPrice >= 0)
// TODO: реализовать конструктор и фабричный метод Create()
// TODO: реализовать свойство Subtotal => UnitPrice * Quantity

public sealed class OrderItem
{
public Sku ProductSku { get; }
public int Quantity { get; private set; }
public Money UnitPrice { get; private set; }

// TODO: вычисляемое свойство Subtotal

// Вычисляемое свойство Subtotal
public Money Subtotal => UnitPrice * Quantity;

// Основной конструктор (private)
private OrderItem(Sku productSku, Money unitPrice, int quantity)
{
    // TODO: добавить проверки инвариантов
    ProductSku = productSku;
    UnitPrice = unitPrice;
    Quantity = quantity;
}

// Фабричный метод Create
public static OrderItem Create(Sku sku, Money price, int qty)
{
    // TODO: добавить проверки перед созданием экземпляра
    return new OrderItem(sku, price, qty);
}
}