FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["meetlocal_backend/meetlocal_backend.csproj", "meetlocal_backend/"]
RUN dotnet restore "meetlocal_backend/meetlocal_backend.csproj"
COPY . .
WORKDIR "/src/meetlocal_backend"
RUN dotnet build "meetlocal_backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "meetlocal_backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "meetlocal_backend.dll"]
