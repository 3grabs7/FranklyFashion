#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FranklyFashion.CatalogService/FranklyFashion.CatalogService.csproj", "FranklyFashion.CatalogService/"]
RUN dotnet restore "FranklyFashion.CatalogService/FranklyFashion.CatalogService.csproj"
COPY . .
WORKDIR "/src/FranklyFashion.CatalogService"
RUN dotnet build "FranklyFashion.CatalogService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FranklyFashion.CatalogService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FranklyFashion.CatalogService.dll"]