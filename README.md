# BookStore API

Это API для управления книжным магазином. API позволяет выполнять CRUD операции с книгами, авторами и категориями.

## Установка и настройка

### Предварительные требования

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Клонирование репозитория

```bash
git clone https://github.com/yourusername/BookStoreAPI.git
cd BookStoreAPI

Настройка базы данных
Откройте файл appsettings.json и настройте строку подключения к вашей базе данных SQL Server:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=BookStoreDB;User Id=your_username;Password=your_password;"
  }
}

Выполните миграции для создания базы данных:
dotnet ef migrations add InitialCreate
dotnet ef database update

Получить все книги
GET /api/books

Получить книгу по ID
GET /api/books/{id}

Создать новую книгу
POST /api/books
Content-Type: application/json

{
  "title": "Название книги",
  "price": 19.99,
  "imageUrl": "http://example.com/image.jpg",
  "categoryId": 1,
  "bookAuthors": [
    {
      "authorId": 1
    }
  ]
}

Обновить книгу
PUT /api/books/{id}
Content-Type: application/json

{
  "id": 1,
  "title": "Обновленное название книги",
  "price": 19.99,
  "imageUrl": "http://example.com/image.jpg",
  "categoryId": 1
}

Удалить книгу
DELETE /api/books/{id}

Получить всех авторов
GET /api/authors

Получить автора по ID
GET /api/authors/{id}


Создать нового автора
**POST /api/authors
Content-Type: application/json

{
  "name": "Имя автора"
}


Структура проекта
Controllers - Контроллеры для обработки HTTP-запросов.
Services - Сервисы для бизнес-логики приложения.
Models - Модели данных.
Data - Контекст базы данных и миграции.
