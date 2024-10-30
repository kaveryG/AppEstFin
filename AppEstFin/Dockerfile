# Establecer la imagen base de .NET Core 8 SDK para construir el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar los archivos de proyecto y restaurar las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y compilar el proyecto
COPY . ./
RUN dotnet publish -c Release -o out

# Establecer la imagen base de runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Configurar el puerto en el que se ejecutará la aplicación
EXPOSE 85

# Comando para iniciar la aplicación
ENTRYPOINT ["dotnet", "AppEstFin.dll"]