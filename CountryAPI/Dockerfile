FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5228

ENV ASPNETCORE_URLS=http://+:5228

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RetailStoreApp.csproj", "./"]
RUN dotnet restore "RetailStoreApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RetailStoreApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RetailStoreApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RetailStoreApp.dll"]
