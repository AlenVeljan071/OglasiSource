#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OglasiSource/OglasiSource.csproj", "OglasiSource/"]
RUN dotnet restore "OglasiSource/OglasiSource.csproj"
COPY . .
WORKDIR "/src/OglasiSource"
RUN dotnet build "OglasiSource.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OglasiSource.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OglasiSource.dll"]