FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY AWS.Sample/AWS.Sample.sln ./
COPY AWS.Sample/AWS.Sample.API/ AWS.Sample.API/
COPY AWS.Sample/AWS.Sample.Application/ AWS.Sample.Application/
COPY AWS.Sample/AWS.Sample.Domain/ AWS.Sample.Domain/
COPY AWS.Sample/AWS.Sample.Infrastructure/ AWS.Sample.Infrastructure/

RUN dotnet restore AWS.Sample.sln

COPY . .

RUN dotnet publish AWS.Sample.API/AWS.Sample.API.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "AWS.Sample.API.dll"]