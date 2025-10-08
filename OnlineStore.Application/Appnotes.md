Репозитории (Порты)

IProductRepository — CRUD, проверка уникальности Sku

ICustomerRepository — CRUD по Id/Email

IOrderRepository — операции над заказами

Use Cases (Сценарии)

CreateProduct, ListProducts, PlaceOrder, PayOrder, CancelOrder

Валидация

DTO проверяются до репозитория

Ошибки: ProductAlreadyExists, InvalidOrderState и т.д.

🔹 Практика:

Опиши DTO (вход/выход) для каждого сценария.

Составь таблицу ошибок: условие → сообщение.

Реши, где происходит проверка уникальности Sku.