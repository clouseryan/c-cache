FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CCache.Web.API/CCache.Web.API.csproj", "CCache.Web.API/"]
RUN dotnet restore "CCache.Web.API/CCache.Web.API.csproj"
COPY . .
WORKDIR "/src/CCache.Web.API"
RUN dotnet build "CCache.Web.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CCache.Web.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CCache.Web.API.dll"]
