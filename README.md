# OnlineStore (.NET 8, Clean Architecture)

# OnlineStore (.NET 8, Clean Architecture)

## Цель
Учебный консольный интернет-магазин (товары, клиенты, заказы) для отработки архитектуры уровня Junior.

## Архитектура (слои)
- **Domain** — бизнес-модель и правила (Entities, ValueObjects, Enums, Exceptions).
- **Application** — сценарии использования и абстракции (UseCases, DTOs, Abstractions).
- **Infrastructure** — технические реализации портов (Repositories, Logging).
- **Console (Presentation)** — пользовательский интерфейс и **Composition Root** (DI).

Зависимости направлены к центру:

Console → Application → Domain
Infrastructure → Application, Domain

`Domain` ни от кого не зависит.

## Проекты
- `OnlineStore.Domain` — сущности: Product, Customer, Order, OrderItem; VO: Money, Email, Sku.
- `OnlineStore.Application` — порты (репозитории), use cases, DTO, валидации.
- `OnlineStore.Infrastructure` — In-Memory репозитории, логирование, регистрация реализаций.
- `OnlineStore.Console` — меню, ввод/вывод, сборка DI.

## MVP функционал
- CRUD для товара и клиента.
- Заказ: создать черновик, добавить/удалить позиции, разместить, оплатить/отменить.
- Статусы: Draft → Placed → Paid | Cancelled.
- Хранение на старте — In-Memory.

## Почему Clean Architecture
- Бизнес-логика не зависит от UI/БД.
- Легко заменить инфраструктуру (In-Memory → EF Core) без переписывания use cases.
- Тестируемость: Application/Domain можно тестировать изолированно.

## Сборка и запуск
```bash
dotnet build OnlineStore.sln
dotnet run --project OnlineStore.Console

Правила кода (коротко)
decimal для денег; все суммы ≥ 0 (инвариант Money).
Id неизменяемые value-объекты.
Изменение заказа только методами агрегата Order.
DTO не «светят» внутреннюю структуру сущностей.
Валидируем вход в Application и инварианты в Domain.
Планы
Спринт 1: моделирование Domain.
Спринт 2: use cases и порты.
Спринт 3: In-Memory репозитории.
Спринт 4: консольный UI и DI.

## 4) Мини-чек
- [ ] Папки есть в каждом проекте.  
- [ ] Во всех `.csproj` включены `Nullable` и `ImplicitUsings`.  
- [ ] `dotnet build` проходит без ошибок.  
- [ ] `README.md` создан в корне.

Что делаем: создаём консольное меню и сценарии взаимодействия.

Меню

Товары / Клиенты / Заказы / Выход

Требования

Повтор запроса при ошибке

Сообщения из Application

Форматированные списки

🔹 Практика:

Нарисуй схему меню

Опиши вывод таблиц

Опиши обработку ошибок

🚀 Спринт 5 — Расширения (по желанию)

Добавь фильтрацию и поиск

Модель скидок / промокодов

Экспорт в CSV/текст

Переход на EF Core

✅ Критерии готовности MVP

Реализованы основные кейсы

Проверки и ошибки работают корректно

UX понятный и читаемый

Архитектура соответствует схеме

🔧 Git‑процесс

Ветки: feature/sprint1-domain, feature/sprint2-application …

Коммиты: короткие, осмысленные

PR: проверка архитектуры и инвариантов

