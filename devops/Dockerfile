# ✅ Этап 1: Сборка
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# ✅ Копируем только файлы проектов для кэширования зависимостей
COPY AWS.Sample/AWS.Sample.sln ./
COPY AWS.Sample/AWS.Sample.API/ AWS.Sample.API/
COPY AWS.Sample/AWS.Sample.Application/ AWS.Sample.Application/
COPY AWS.Sample/AWS.Sample.Domain/ AWS.Sample.Domain/
COPY AWS.Sample/AWS.Sample.Infrastructure/ AWS.Sample.Infrastructure/

# ✅ Восстанавливаем зависимости
RUN dotnet restore AWS.Sample.sln --disable-parallel

# ✅ Копируем весь исходный код после восстановления зависимостей
COPY . .

# ✅ Собираем проект
RUN dotnet publish AWS.Sample.API/AWS.Sample.API.csproj -c Release -o /app/publish --no-restore

# ✅ Этап 2: Запуск
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "AWS.Sample.API.dll"]