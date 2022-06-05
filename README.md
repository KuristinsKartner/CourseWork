# README #

### How to run app?

`docker-compose -f ./docker-compose.override.yml up`

By default API available at `http://localhost:5102/`

To run app with MySQL server:

`docker-compose -f ./docker-compose.withmysql.yml up`

To run MySQL server only:

`docker-compose -f ./docker-compose.mysqlonly.yml up`

### EF Core migrations

To create migrations:
`dotnet ef migrations add InitialCreate --context RegistryAppContext`

To update database:
`dotnet ef database update --context RegistryAppContext`