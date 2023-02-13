FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /CurrencyAPI
EXPOSE 5031

ENV ASPNETCORE_URLS=http://+:5031

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CurrencyAPI/CurrencyAPI.csproj", "CurrencyAPI/"]
RUN dotnet restore "CurrencyAPI\CurrencyAPI.csproj"
COPY . .
WORKDIR "/src/CurrencyAPI"
RUN dotnet build "CurrencyAPI.csproj" -c Release -o /CurrencyAPI/build

FROM build AS publish
RUN dotnet publish "CurrencyAPI.csproj" -c Release -o /CurrencyAPI/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /CurrencyAPI
COPY --from=publish /CurrencyAPI/publish .
ENTRYPOINT ["dotnet", "CurrencyAPI.dll"]
