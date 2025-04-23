# Establece la imagen base de ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# Expone el puerto 80 para que el contenedor sea accesible desde fuera
EXPOSE 80

# Usamos la imagen SDK para construir el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia los archivos de solución y los proyectos .csproj
COPY ["DDD.BackEndTiendaProductos.sln", "./"]
COPY ["src/DDD.BackEndTiendaProductos.Aplication/DDD.BackEndTiendaProductos.Aplication.csproj", "src/DDD.BackEndTiendaProductos.Aplication/"]
COPY ["src/DDD.BackEndTiendaProductos.Business/DDD.BackEndTiendaProductos.Business.csproj", "src/DDD.BackEndTiendaProductos.Business/"]
COPY ["src/DDD.BackEndTiendaProductos.Domain/DDD.BackEndTiendaProductos.Domain.csproj", "src/DDD.BackEndTiendaProductos.Domain/"]
COPY ["src/DDD.BackEndTiendaProductos.Infrastructure/DDD.BackEndTiendaProductos.Infrastructure.csproj", "src/DDD.BackEndTiendaProductos.Infrastructure/"]
COPY ["src/DDD.BackEndTiendaProductos.WebApi/DDD.BackEndTiendaProductos.WebApi.csproj", "src/DDD.BackEndTiendaProductos.WebApi/"]

# Restaura las dependencias
RUN dotnet restore "DDD.BackEndTiendaProductos.sln"

# Copia el código fuente y lo publica en el directorio /app/publish
COPY . . 
RUN dotnet publish "src/DDD.BackEndTiendaProductos.WebApi/DDD.BackEndTiendaProductos.WebApi.csproj" -c Release -o /app/publish

# Establece la imagen base para el contenedor final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish . 
ENTRYPOINT ["dotnet", "DDD.BackEndTiendaProductos.WebApi.dll"]
