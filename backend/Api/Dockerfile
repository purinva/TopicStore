# Этап базового образа
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Копируем файлы проектов
COPY ["Api/Api.csproj", "Api/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]

# Восстанавливаем зависимости
RUN dotnet restore "Api/Api.csproj"

# Копируем весь контекст
COPY . .

# Переходим в папку Api и собираем проект
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c ${BUILD_CONFIGURATION} -o /app/build

# Этап публикации
FROM build AS publish
RUN dotnet publish "Api.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish /p:UseAppHost=false

# Финальный образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]