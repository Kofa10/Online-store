Поля: Id, Sku, Name, Price (Money), StockQuantity, IsActive.
Связи: Product не зависит от заказов; используется внутри OrderItem.
Ответственность: хранит состояние товара и гарантирует корректные операции над ценой/остатком/статусом.
Инварианты (всегда верно):
Name не пустой, без только пробелов.
Price.Amount >= 0.
StockQuantity >= 0.
Sku нормализован (напр. Trim + Upper) и не пустой.
Если IsActive == false, товар нельзя добавить в заказа́х (правило домена — сформулируй явно).
Операции Product (словами + предусловия/постусловия):
ChangeName(newName) — предусл.: not null/blank; пост.: Name обновлён.
ChangePrice(newMoney) — предусл.: amount ≥ 0; пост.: Price обновлён.
IncreaseStock(qty) — предусл.: qty > 0; пост.: Stock += qty.
DecreaseStock(qty) — предусл.: qty > 0 и Stock - qty ≥ 0; пост.: Stock -= qty.
Activate()/Deactivate() — опиши, как влияет на возможность продаж.
Подсказка: фиксируй ошибки домена (имена и условия), например:
InvalidProductName, InvalidSku, InvalidMoneyAmount, NegativeStockChange, InsufficientStock, ProductDeactivated.

Шаг 2: Спроектируй Value Objects
Опиши что хранит, как сравнивается, какие проверки делает.
Money
Поля: decimal Amount (валюту в MVP игнорируем).
Инвариант: Amount ≥ 0.
Операции: сложение сумм, умножение на количество (целое > 0).
Ошибки: InvalidMoneyAmount.
Поле: string Value.
Нормализация: Trim() + единый регистр.
Инвариант: не пустой/не null.
Сравнение по значению (нормализованному).
Ошибки: InvalidSku.
ProductId (опционально)
Идентификатор (Guid/long — выбери и обоснуй).
Неизменяемый, сравнение по значению.
Подсказка: VO должны быть неизменяемыми и сравниваться по значению.
Шаг 3: Эскиз Order как агрегата
Пока только текстом:
Почему Order — Aggregate Root (контролирует список OrderItem и целостность заказа).
Поля: OrderId, CustomerId, CreatedAt, Status, Items, Total (Money).
Переходы статусов (разрешённые и запрещённые).
Когда списывается склад: на PlaceOrder или на PayOrder — выбери стратегию и аргументируй.
Подсказка: если списывать на PlaceOrder, это резерв/списание раньше оплаты; если на PayOrder — риск отсутствия товара при долгой оплате. Для учебного проекта чаще берут списание на Place.
Шаг 4: Мини-проверка (ответь тут, коротко)
Зачем VO Money, если можно везде decimal?
Где и когда проверяется уникальность Sku без БД?
Что нарушится, если разрешить Quantity = 0 в OrderItem?
Когда корректно разрешать DecreaseStock(qty) и какое сообщение ошибки отдавать при недостатке?
Частые ошибки (избегай)
Смешивать проверки формата Email/Sku в UI — их место в VO/Domain.
Делать Total устанавливаемым извне — это derived value: считается из Items.
Давать доступ к изменению списка Order.Items напрямую — модификации только через методы агрегата.

1) Enum статуса
OnlineStore.Domain/Enums/OrderStatus.cs
Значения: Draft = 0, Placed = 1, Paid = 2, Cancelled = 3.
2) OrderItem (каркас)
Файл: Entities/OrderItem.cs
Поля: Sku ProductSku, int Quantity, Money UnitPrice.
Свойство: Money Subtotal => UnitPrice * Quantity.
Инварианты: Quantity > 0, UnitPrice >= 0.
3) Order (каркас)
Файл: Entities/Order.cs
Поля: Guid OrderId, Guid CustomerId, DateTime CreatedAt, OrderStatus Status, IReadOnlyCollection<OrderItem> Items, Money Total.
Методы (пока только сигнатуры + TODO внутри):
AddItem(Sku sku, Money unitPrice, int quantity)
RemoveItem(Sku sku)
Place()
Pay()
Cancel(string reason)
Правила переходов:
Draft → Placed → Paid
Draft/Placed → Cancelled
Запрещено: Paid → Cancelled
Инварианты:
Нельзя Place, если Items пуст.
Total — вычисляемое значение (сумма Subtotal по позициям), не сеттится извне.
4) Доменные ошибки, если ещё нет
InvalidOrderState
EmptyOrderItems
(Если нужно) DuplicateOrderItem при добавлении одинакового Sku.
