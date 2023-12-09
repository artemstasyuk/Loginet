# Задания для компании Loginet
## Содержание

- [Задание](#задание)
  - [Требования](#требования)
- [Технологии](#технологии)
  - [Как запустить](#запуск)
 
## Задание
Создайте веб сервис, который предоставляет следующие методы API:

1. Получение списка всех пользователей
2. Получение пользователя по id
3. Получение списка всех альбомов
4. Получение всех альбомов одного пользователя
5. Получение альбома по id

## Требования
1. Код должен быть написан на языке С# (Visual Studio Community бесплатна https://www.visualstudio.com/vs/community/).
2. Сервис должен быть написан на .NET 6 c использованием ASP.NET Core.
3. Методы сервиса должен предоставлять данные в формате JSON.
4. Для доступа к БД желательно использовать ORM (EF Core, NHibernate, Dapper).

## Технологии 

* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
* [Serilog](https://serilog.net/)
* [PostgreSQL](https://www.postgresql.org/)
  
## Запуск
1. Поменяйте строку подключения к бд. конфиг находится в appsetting.json в проекте Loginet.Web
```json
 "ConnectionStrings": {
    "Postgres": "Host=localhost;Port=5432;Database=loginet-db;Username={your-name};Password={your-password}"
  },
```
2.  Запустите проект, миграция накатиться автоматически
3. При первом обращении к API, должны вызываться методы пользователя, т.к при обращении методов получения альбомов я оставил уязвимость в виде fk ошибки при добавлении в бд




