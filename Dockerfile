FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
COPY ["Correspondence/Correspondence.csproj", "Correspondence/"]
RUN dotnet restore "Correspondence/Correspondence.csproj"
COPY . .
WORKDIR /Correspondence
RUN dotnet build "Correspondence.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Correspondence.csproj" -c Release -o /app/publish

FROM base AS final

# MSSQL connection healthcheck script
COPY wait-for.sh /wait-for.sh
RUN chmod +x /wait-for.sh

# Start app
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Correspondence.dll"]
