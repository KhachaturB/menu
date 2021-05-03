FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Menu.Api/Menu.Api.csproj", "Menu.Api/"]
RUN dotnet restore "Menu.Api/Menu.Api.csproj"
COPY . .
WORKDIR "/src/Menu.Api"
RUN dotnet build "Menu.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Menu.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Menu.Api.dll"]